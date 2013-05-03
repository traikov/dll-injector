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
using System.Runtime.InteropServices;

namespace DllInjector.Win32
{
    class Imports
    {
        #region Load/FreeLibrary
        /// <summary>
        /// Loads the specified module into the address space of the calling process.
        /// </summary>
        /// <param name="lpFileName">The name of the module.</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern IntPtr LoadLibrary(
            string lpFileName
            );

        /// <summary>
        /// Frees the loaded dynamic-link library (DLL) module.
        /// </summary>
        /// <param name="hModule">A handle to the loaded library module.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);
        #endregion

        #region OpenProcess
        /// <summary>
        /// Open process for external manipulation.
        /// </summary>
        /// <param name="dwDesiredAccess">The desired access to the external program.</param>
        /// <param name="bInheritHandle">Whether or not we wish to inherit a handle.</param>
        /// <param name="dwProcessId">The unique process ID of the external program.</param>
        /// <returns>Returns a process handle used in memory manipulation.</returns>
        [DllImport("kernel32", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess(
            AccessRights dwDesiredAccess,
            bool bInheritHandle,
            int dwProcessId);
        #endregion

        #region CloseHandle
        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="hObject">The object handle we wish to close.</param>
        /// <returns>Returns non-zero if success, zero if failure.</returns>
        [DllImport("kernel32", EntryPoint = "CloseHandle")]
        public static extern bool CloseHandle(IntPtr hObject);
        #endregion

        #region ProcAddress
        /// <summary>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// </summary>
        /// <param name="lpModuleName">
        /// The name of the loaded module (either a .dll or .exe file). If the file name extension is omitted, the default library extension .dll is appended. The file name string can include a trailing point character (.) to indicate that the module name has no extension. The string does not have to specify a path. When specifying a path, be sure to use backslashes (\), not forward slashes (/). The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process.
        ///
        /// If this parameter is NULL, GetModuleHandle returns a handle to the file used to create the calling process (.exe file).
        /// </param>
        /// <returns>If success, returns the base address of the module; if failure, returns IntPtr.Zero.</returns>
        [DllImport("kernel32", EntryPoint = "GetModuleHandleW")]
        public static extern IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)] string lpModuleName);

        /// <summary>
        /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
        /// </summary>
        /// <param name="hModule">A handle to the DLL module that contains the function or variable.</param>
        /// <param name="lpProcName">The function or variable name, or the function's ordinal value. If this parameter is an ordinal value, it must be in the low-order word; the high-order word must be zero.</param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the exported function or variable.
        /// 
        /// If the function fails, the return value is NULL (IntPtr.Zero).
        /// </returns>
        [DllImport("kernel32")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string lpProcName);
        #endregion

        #region Read/WriteProcessMemory
        /// <summary>
        /// Reads raw bytes from another process' memory.
        /// </summary>
        /// <param name="hProcess">Handle to the external process.</param>
        /// <param name="dwAddress">Address from which to read.</param>
        /// <param name="lpBuffer">[Out] Allocated buffer into which raw bytes will be read. (Hint: Use Marshal.AllocHGlobal)</param>
        /// <param name="nSize">Number of bytes to be read.</param>
        /// <param name="lpBytesRead">[Out] Number of bytes actually read.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        [DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory(
            IntPtr hProcess,
            uint dwAddress,
            IntPtr lpBuffer,
            int nSize,
            out int lpBytesRead);

        /// <summary>
        /// Writes raw bytes to another process' memory.
        /// </summary>
        /// <param name="hProcess">Handle to the external process.</param>
        /// <param name="dwAddress">Address to which bytes will be written.</param>
        /// <param name="lpBuffer">Unmanaged buffer that will be written to process in question.</param>
        /// <param name="nSize">Number of bytes to be written.</param>
        /// <param name="iBytesWritten">[Out] Number of bytes actually written.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        [DllImport("kernel32", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr dwAddress,
            byte[] lpBuffer, /* IntPtr lpBuffer */
            int nSize,
            out IntPtr iBytesWritten);
        #endregion

        #region AllocateFreeMemory
        /// <summary>
        /// Reserves or commits a region of memory within the virtual address space of a specified process. The function initializes the memory it allocates to zero, unless MEM_RESET is used.
        /// </summary>
        /// <param name="hProcess">The handle to a process. The function allocates memory within the virtual address space of this process.</param>
        /// <param name="dwAddress">The pointer that specifies a desired starting address for the region of pages that you want to allocate. (optional)</param>
        /// <param name="nSize">The size of the region of memory to allocate, in bytes.  If dwAddress is null, nSize is rounded up to the next page boundary.</param>
        /// <param name="dwAllocationType">The type of memory allocation. </param>
        /// <param name="dwProtect">The memory protection for the region of pages to be allocated.</param>
        /// <returns></returns>
        [DllImport("kernel32", EntryPoint = "VirtualAllocEx")]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, uint dwAddress, int nSize, MemoryAllocationType dwAllocationType, MemoryProtectionType dwProtect);

        /// <summary>
        /// Releases, decommits, or releases and decommits a region of memory within the virtual address space of a specified process.
        /// </summary>
        /// <param name="hProcess">A handle to a process. The function frees memory within the virtual address space of the process. </param>
        /// <param name="dwAddress">A pointer to the starting address of the region of memory to be freed. </param>
        /// <param name="nSize">The size of the region of memory to free, in bytes.  If the dwFreeType parameter is MEM_RELEASE, dwSize must be 0 (zero). The function frees the entire region that is reserved in the initial allocation call to VirtualAllocEx.</param>
        /// <param name="dwFreeType">The type of free operation.  See Imports.MemoryFreeType.</param>
        /// <returns>If the function succeeds, the return value is a nonzero value.  If the function fails, the return value is 0 (zero).</returns>
        [DllImport("kernel32", EntryPoint = "VirtualFreeEx")]
        public static extern bool VirtualFreeEx(IntPtr hProcess, uint dwAddress, int nSize, MemoryFreeType dwFreeType);
        #endregion

        #region Thread
        /// <summary>
        /// Creates a thread that runs in the virtual address space of another process.
        /// </summary>
        /// <param name="hProcess">A handle to the process in which the thread is to be created.</param>
        /// <param name="lpThreadAttributes">A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new thread and determines whether child processes can inherit the returned handle. If lpThreadAttributes is NULL, the thread gets a default security descriptor and the handle cannot be inherited.</param>
        /// <param name="dwStackSize">The initial size of the stack, in bytes. The system rounds this value to the nearest page. If this parameter is 0 (zero), the new thread uses the default size for the executable.</param>
        /// <param name="lpStartAddress">A pointer to the application-defined function of type LPTHREAD_START_ROUTINE to be executed by the thread and represents the starting address of the thread in the remote process. The function must exist in the remote process.</param>
        /// <param name="lpParameter">A pointer to a variable to be passed to the thread function.</param>
        /// <param name="dwCreationFlags">The flags that control the creation of the thread.</param>
        /// <param name="dwThreadId">A pointer to a variable that receives the thread identifier.</param>
        /// <returns>If the function succeeds, the return value is a handle to the new thread.  If the function fails, the return value is IntPtr.Zero.</returns>
        [DllImport("kernel32", EntryPoint = "CreateRemoteThread")]
        public static extern IntPtr CreateRemoteThread(
            IntPtr hProcess,
            IntPtr lpThreadAttributes,
            uint dwStackSize,
            IntPtr lpStartAddress,
            IntPtr lpParameter,
            ThreadFlags dwCreationFlags,
            out IntPtr dwThreadId);

        /// <summary>
        /// Waits until the specified object is in the signaled state or the time-out interval elapses.
        /// </summary>
        /// <param name="hObject">A handle to the object. For a list of the object types whose handles can be specified, see the following Remarks section.</param>
        /// <param name="dwMilliseconds">The time-out interval, in milliseconds. The function returns if the interval elapses, even if the object's state is nonsignaled. If dwMilliseconds is zero, the function tests the object's state and returns immediately. If dwMilliseconds is INFINITE, the function's time-out interval never elapses.</param>
        /// <returns>If the function succeeds, the return value indicates the event that caused the function to return. If the function fails, the return value is WAIT_FAILED ((DWORD)0xFFFFFFFF).</returns>
        [DllImport("kernel32", EntryPoint = "WaitForSingleObject")]
        public static extern uint WaitForSingleObject(IntPtr hObject, uint dwMilliseconds);

        /// <summary>
        /// Retrieves the termination status of the specified thread.
        /// </summary>
        /// <param name="hThread">A handle to the thread.</param>
        /// <param name="lpExitCode">[Out] The exit code of the thread.</param>
        /// <returns>A pointer to a variable to receive the thread termination status.For more information.</returns>
        [DllImport("kernel32", EntryPoint = "GetExitCodeThread")]
        public static extern bool GetExitCodeThread(IntPtr hThread, out IntPtr lpExitCode);

        /// <summary>
        /// Opens an existing thread object.
        /// </summary>
        /// <param name="dwDesiredAccess">The access to the thread object. This access right is checked against the security descriptor for the thread. This parameter can be one or more of the thread access rights.</param>
        /// <param name="bInheritHandle">If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
        /// <param name="dwThreadId">The identifier of the thread to be opened.</param>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified thread.
        /// 
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("kernel32", EntryPoint = "OpenThread")]
        public static extern IntPtr OpenThread(uint dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

        /// <summary>
        /// Suspends execution of a given thread.
        /// </summary>
        /// <param name="hThread">Handle to the thread that will be suspended.</param>
        /// <returns>Returns (DWORD)-1 on failure, otherwise the suspend count of the thread.</returns>
        [DllImport("kernel32", EntryPoint = "SuspendThread")]
        public static extern uint SuspendThread(IntPtr hThread);

        /// <summary>
        /// Resumes execution of a given thread.
        /// </summary>
        /// <param name="hThread">Handle to the thread that will be suspended.</param>
        /// <returns>Returns (DWORD)-1 on failure, otherwise the previous suspend count of the thread.</returns>
        [DllImport("kernel32", EntryPoint = "ResumeThread")]
        public static extern uint ResumeThread(IntPtr hThread);

        /// <summary>
        /// Terminates the specified thread.
        /// </summary>
        /// <param name="hThread">Handle to the thread to exit.</param>
        /// <param name="dwExitCode">Exit code that will be stored in the thread object.</param>
        /// <returns>Returns zero on failure, non-zero on success.</returns>
        [DllImport("kernel32", EntryPoint = "TerminateThread")]
        public static extern uint TerminateThread(IntPtr hThread, uint dwExitCode);
        #endregion
    }
}