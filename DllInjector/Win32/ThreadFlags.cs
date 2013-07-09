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

namespace DllInjector.Win32
{
    /// <summary>
    /// Values which determine the state or creation-state of a thread.
    /// </summary>
    [Flags]
    public enum ThreadFlags : uint
    {
        /// <summary>
        /// The thread will execute immediately.
        /// </summary>
        THREAD_EXECUTE_IMMEDIATELY = 0,
        /// <summary>
        /// The thread will be created in a suspended state.  Use <see cref="Imports.ResumeThread"/> to resume the thread.
        /// </summary>
        CREATE_SUSPENDED = 0x04,
        /// <summary>
        /// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize specifies the commit size.
        /// </summary>
        STACK_SIZE_PARAM_IS_A_RESERVATION = 0x00010000,
        /// <summary>
        /// The thread is still active.
        /// </summary>
        STILL_ACTIVE = 259
    }
}
