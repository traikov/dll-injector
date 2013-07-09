// Dll Injector
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
using DllInjector.Win32;

namespace DllInjector.Utils
{
    public static class SThread
    {
        /// <summary>
        /// Creates a thread inside another process' context.
        /// </summary>
        /// <param name="hProcess">Handle to the process inside which thread will be created.</param>
        /// <param name="dwStartAddress">Address at which thread will start.</param>
        /// <param name="dwParameter">Parameter that will be passed to the thread.</param>
        /// <returns>Returns the handle of the created thread.</returns>
        public static IntPtr CreateRemoteThread(IntPtr hProcess, uint dwStartAddress, uint dwParameter)
        {
            uint dwThreadId;
            return CreateRemoteThread(hProcess, dwStartAddress, dwParameter, ThreadFlags.THREAD_EXECUTE_IMMEDIATELY, out dwThreadId);
        }

        /// <summary>
        /// Creates a thread inside another process' context.
        /// </summary>
        /// <param name="hProcess">Handle to the process inside which thread will be created.</param>
        /// <param name="dwStartAddress">Address at which thread will start.</param>
        /// <param name="dwParameter">Parameter that will be passed to the thread.</param>
        /// /// <param name="dwThreadId">[Out] The id of the created thread.</param>
        /// <returns>Returns the handle of the created thread.</returns>
        public static IntPtr CreateRemoteThread(IntPtr hProcess, uint dwStartAddress, uint dwParameter, out uint dwThreadId)
        {
            return CreateRemoteThread(hProcess, dwStartAddress, dwParameter, ThreadFlags.THREAD_EXECUTE_IMMEDIATELY, out dwThreadId);
        }

        /// <summary>
        /// Creates a thread inside another process' context.
        /// </summary>
        /// <param name="hProcess">Handle to the process inside which thread will be created.</param>
        /// <param name="dwStartAddress">Address at which thread will start.</param>
        /// <param name="dwParameter">Parameter that will be passed to the thread.</param>
        /// <param name="dwCreationFlags">Flags that control creation of the thread.</param>
        /// <param name="dwThreadId">[Out] The id of the created thread.</param>
        /// <returns>Returns the handle of the created thread.</returns>
        public static IntPtr CreateRemoteThread(IntPtr hProcess, uint dwStartAddress, uint dwParameter, ThreadFlags dwCreationFlags, out uint dwThreadId)
        {
            IntPtr hThread, lpThreadId;

            hThread = Imports.CreateRemoteThread(hProcess, IntPtr.Zero, 0, (IntPtr)dwStartAddress, (IntPtr)dwParameter, dwCreationFlags, out lpThreadId);
            dwThreadId = (uint)lpThreadId;

            return hThread;
        }
    }
}