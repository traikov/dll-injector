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
using System.Diagnostics;
using DllInjector.Win32;

namespace DllInjector.Utils
{
    public static class SProcess
    {
        /// <summary>
        /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
        /// </summary>
        /// <param name="module"></param>
        /// <param name="procName"></param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the exported function or variable. 
        /// If the function fails, throws Exception.
        /// </returns>
        public static IntPtr GetProcAddress(IntPtr module, string procName)
        {
            IntPtr procAddress = Imports.GetProcAddress(module, procName);
            if (procAddress == IntPtr.Zero)
            {
                throw new Exception("GetProcAddress failed.");
            }
            return procAddress;
        }

        /// <summary>
        /// Check if process contains Dll(module).
        /// </summary>
        /// <param name="process">Process to check.</param>
        /// <param name="dllPath">Path to the dll to check for.</param>
        /// <returns>Returns true if process contains the given module.</returns>
        public static bool ContainsDll(Process process, string dllPath)
        {
            if (process == null)
                throw new NullReferenceException("process cannot be null.");

            process.Refresh();
            foreach (ProcessModule module in process.Modules)
            {
                if (module.FileName == dllPath)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
