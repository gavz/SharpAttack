# SharpAttack

SharpAttack is a console for certain things I use often during security assessments. It leverages .NET and the Windows API to perform its work. It contains commands for domain enumeration, code execution, and other fun things.

## Building

SharpAttack is distributed as source code. Binaries will not be made available. To build SharpAttack:

1. Clone the repo with `git clone --recursive https://github.com/jaredhaight/SharpAttack`
2. Build with a recent version of Microsoft's [Visual Studio](https://visualstudio.microsoft.com/vs/). The free, community edition will work fine. Make sure that when you build the project, you're targeting the version of .NET thats appropriate for your needs. You should get a copy of SharpAttack.exe and SharpSploit.dll
3. You can use Microsoft's [ILMerge](https://www.microsoft.com/en-us/download/details.aspx?id=17630) to merge SharpSploit.dll with the SharpAttack executable into a single file (`.\ILMerge.exe SharpAttack.exe SharpSploit.dll /out:.\SharpAttackBundle.exe`). Make sure to delete any pdb files before doing this else you'll get errors.

## Thanks
SharpAttack is built on top of Cobbr's incredible [SharpSploit Project](https://github.com/cobbr/SharpSploit). SHarpAttack is basically an easy way to interact with SharpSploit.
