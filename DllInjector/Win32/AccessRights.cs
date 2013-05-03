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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DllInjector.Win32
{
    /// <summary>
    /// Values to gain required access to process or thread.
    /// </summary>
    //[Flags]
    public enum AccessRights : uint
    {
        /// <summary>
        /// Standard rights required to mess with an object's security descriptor, change, or delete the object.
        /// </summary>
        STANDARD_RIGHTS_REQUIRED = 0x000F0000,
        /// <summary>
        /// The right to use the object for synchronization. This enables a thread to wait until the object is in the signaled state. Some object types do not support this access right.
        /// </summary>
        SYNCHRONIZE = 0x00100000,

        /// <summary>
        /// Required to terminate a process using TerminateProcess.
        /// </summary>
        PROCESS_TERMINATE = 0x0001,
        /// <summary>
        /// Required to create a thread.
        /// </summary>
        PROCESS_CREATE_THREAD = 0x0002,
        //PROCESS_SET_SESSIONID = 0x0004,
        /// <summary>
        /// Required to perform an operation on the address space of a process (see VirtualProtectEx and WriteProcessMemory).
        /// </summary>
        PROCESS_VM_OPERATION = 0x0008,
        /// <summary>
        /// Required to read memory in a process using ReadProcessMemory.
        /// </summary>
        PROCESS_VM_READ = 0x0010,
        /// <summary>
        /// Required to write memory in a process using WriteProcessMemory.
        /// </summary>
        PROCESS_VM_WRITE = 0x0020,
        /// <summary>
        /// Required to duplicate a handle using DuplicateHandle.
        /// </summary>
        PROCESS_DUP_HANDLE = 0x0040,
        /// <summary>
        /// Required to create a process.
        /// </summary>
        PROCESS_CREATE_PROCESS = 0x0080,
        /// <summary>
        /// Required to set memory limits using SetProcessWorkingSetSize.
        /// </summary>
        PROCESS_SET_QUOTA = 0x0100,
        /// <summary>
        /// Required to set certain information about a process, such as its priority class (see SetPriorityClass).
        /// </summary>
        PROCESS_SET_INFORMATION = 0x0200,
        /// <summary>
        /// Required to retrieve certain information about a process, such as its token, exit code, and priority class (see OpenProcessToken, GetExitCodeProcess, GetPriorityClass, and IsProcessInJob).
        /// </summary>
        PROCESS_QUERY_INFORMATION = 0x0400,
        /// <summary>
        /// Required to suspend or resume a process.
        /// </summary>
        PROCESS_SUSPEND_RESUME = 0x0800,
        /// <summary>
        /// Required to retrieve certain information about a process (see QueryFullProcessImageName). A handle that has the PROCESS_QUERY_INFORMATION access right is automatically granted PROCESS_QUERY_LIMITED_INFORMATION.
        /// </summary>
        PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,

        /// <summary>
        /// All possible access rights for a process object.
        /// </summary>
        PROCESS_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFF,//0x001F0FFF on WinXP, should be changed to 0xFFFF on Vista/2k8

        /// <summary>
        /// Required to terminate a thread using TerminateThread.
        /// </summary>
        THREAD_TERMINATE = 0x0001,
        /// <summary>
        /// Required to suspend or resume a thread.
        /// </summary>
        THREAD_SUSPEND_RESUME = 0x0002,
        /// <summary>
        /// Required to read the context of a thread using <see cref="Imports.GetThreadContext"/>
        /// </summary>
        THREAD_GET_CONTEXT = 0x0008,
        /// <summary>
        /// Required to set the context of a thread using <see cref="Imports.SetThreadContext"/>
        /// </summary>
        THREAD_SET_CONTEXT = 0x0010,
        /// <summary>
        /// Required to read certain information from the thread object, such as the exit code (see GetExitCodeThread).
        /// </summary>
        THREAD_QUERY_INFORMATION = 0x0040,
        /// <summary>
        /// Required to set certain information in the thread object.
        /// </summary>
        THREAD_SET_INFORMATION = 0x0020,
        /// <summary>
        /// Required to set the impersonation token for a thread using SetThreadToken.
        /// </summary>
        THREAD_SET_THREAD_TOKEN = 0x0080,
        /// <summary>
        /// Required to use a thread's security information directly without calling it by using a communication mechanism that provides impersonation services.
        /// </summary>
        THREAD_IMPERSONATE = 0x0100,
        /// <summary>
        /// Required for a server thread that impersonates a client.
        /// </summary>
        THREAD_DIRECT_IMPERSONATION = 0x0200,

        /// <summary>
        /// All possible access rights for a thread object.
        /// </summary>
        THREAD_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0x3FF,
    }
}