﻿// Dll Injector
// Copyright (C) 2013 Filip Traikov
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Text;
using System.Diagnostics;
using DllInjector.Win32;
using DllInjector.Memory;
using DllInjector.Utils;

namespace DllInjector
{
    class Injector
    {
        public delegate void OnDllInjectErrorDelegate(object sender, InjectorExceptionEventArgs e);
        public static event OnDllInjectErrorDelegate OnDllInjectErrorEventHandler;

        /// <summary>
        /// Inject .DLL into program.
        /// </summary>
        /// <param name="process">Process handle</param>
        /// <param name="dllPath">Path to the .DLL file</param>
        /// <returns>Returns true if function succeed.</returns>
        public static bool InjectDll(Process process, string dllPath)
        {
            if (SProcess.ContainsDll(process, dllPath))
            {
                OnDllInjectErrorEventHandler(0, new InjectorExceptionEventArgs("Dll already injected.", InjectorExceptionType.Notification));
                return false;
            }
            
            IntPtr processHandle = Win32.Imports.OpenProcess(
                Win32.AccessRights.PROCESS_VM_OPERATION | Win32.AccessRights.PROCESS_VM_READ |
                Win32.AccessRights.PROCESS_VM_WRITE | Win32.AccessRights.PROCESS_CREATE_THREAD |
                Win32.AccessRights.PROCESS_QUERY_INFORMATION,
                false,
                process.Id);

            if (processHandle == IntPtr.Zero)
                return false;

            try
            {
                return InjectDll(processHandle, dllPath);
            }
            catch (Exception ex)
            {
                OnDllInjectErrorEventHandler(0, new InjectorExceptionEventArgs(ex, InjectorExceptionType.Fatal));
                return false;
            }
            finally
            {
                if (processHandle != IntPtr.Zero)
                    Win32.Imports.CloseHandle(processHandle);
            }
        }

        private static bool InjectDll(IntPtr processHandle, string dllPath)
        {
            IntPtr parameterAddress = IntPtr.Zero;
            try
            {
                parameterAddress = SMemory.AllocateMemory(processHandle, dllPath.Length,
                    Win32.MemoryAllocationType.MEM_COMMIT, Win32.MemoryProtectionType.PAGE_READWRITE);

                byte[] buffer = UTF8Encoding.UTF8.GetBytes(dllPath);
                bool isMemoryWritten = SMemory.WriteProcessMemory(processHandle, parameterAddress, buffer, buffer.Length + 1);
                if (!isMemoryWritten)
                {
                    throw new Exception("WriteProcessMemory failed.");
                }

                IntPtr kernel32dllHandle = Imports.GetModuleHandle("kernel32.dll");
                IntPtr loadLibraryAddress = SProcess.GetProcAddress(kernel32dllHandle, "LoadLibraryA");
                IntPtr remoteThreadHandle = SThread.CreateRemoteThread(processHandle, (uint)loadLibraryAddress, (uint)parameterAddress);
                if (remoteThreadHandle != IntPtr.Zero)
                {
                    Imports.WaitForSingleObject(remoteThreadHandle, (uint)WaitValues.INFINITE);
                    Imports.CloseHandle(remoteThreadHandle);

                    return true;
                }

                return false;
            }
            finally
            {
                if (parameterAddress != IntPtr.Zero)
                    SMemory.FreeMemory(processHandle, (uint)parameterAddress);
            }
        }
    }

    public enum InjectorExceptionType
    {
        Notification,
        Fatal
    }

    public class InjectorExceptionEventArgs : EventArgs
    {
        Exception exception;
        InjectorExceptionType exceptionType;

        public InjectorExceptionEventArgs(string message, InjectorExceptionType type)
            : this(message, null, type)
        {
        }

        public InjectorExceptionEventArgs(Exception ex, InjectorExceptionType type)
            : this(ex.Message, ex, type)
        {
        }

        public InjectorExceptionEventArgs(string message, Exception innerException, InjectorExceptionType type)
        {
            exception = new Exception(message, innerException);
            exceptionType = type;
        }

        public Exception Exception
        {
            get { return exception; }
        }

        public string Message
        {
            get { return exception.Message; }
        }

        public InjectorExceptionType Type
        {
            get { return exceptionType; }
        }

    }
}