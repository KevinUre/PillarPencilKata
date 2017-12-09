# Pillar Pencil Kata Readme

This project is a completion of the [Pencil Durability Kata](https://github.com/PillarTechnology/kata-pencil-durability)

The project compiles a GUI that can utilize the pencil's functionality.

# Question for the Customer

over the course of the kata I encountered a question that I would ask the customer on the next checkpoint. How would they like to handle the case where they are inserving a word via the edit functionality and multiple *gaps* are present? First Gap? Last? User selection? What if one gaps fits the inserted word and one doesn't?

# Running the Tests

Download the release. it contains the compiled tests as well as a copy of the testing application if needed. inside the zip there will be a zip for the build and a zip for the testing framework, unpack the build. **do not use the runtests.bat included with the source, its broke**

### If you have visual studio installed

Open the Developer Command Prompt and run `vstest.console.exe ["PATH"]`, where path is the path to `PencilAppTests.dll` which was included in the build.

ex. `vstest.console.exe "C:\Users\Kevin\SkyDrive\Visual Studio Projects\PillarKata\BuildCommit31\PencilAppTests.dll"`

### If you do NOT have visual studio installed

unpack the testing framework included in the release. inside is a copy of `vstest.console.exe`. open an elevated command prompt and navigate to that folder. Run `vstest.console.exe ["PATH"]`, where path is the path to `PencilAppTests.dll` which was included in the build.

ex. `vstest.console.exe "C:\Users\Kevin\SkyDrive\Visual Studio Projects\PillarKata\BuildCommit31\PencilAppTests.dll"`

If the window simply says `Starting test execition, please wait...` then returns to command line check to see that you have .NET Framework 4.0, 4.5, and 4.5.1 redistributables installed.
