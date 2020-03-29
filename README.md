**Snap Game Simulation 


This game simultation has two users that pick cards from a randomly shuffled deck. 
A random time delay is used before each turn of the card to simulate think time.
The cards value, not suit, is then compared against the previous cards value and if a match,
the system starts two parallel process that sleep for a random period of time between 300 and 1000 milliseconds
to simulate reaction time to the snap and picking a winner at randome. The first process 
to complete is the winner and the game ends.If the card value does not match the previous,
the turn moves to the next player. If no winner is found after all the cards have been 
drawn the game is declared a draw.

This is a .Net Core 2.1 application written in C# and requires the .Net Command Line Tool
to be installed in order to run and/or compile it on the command line, unless this is being opened 
in an IDE such and Visual Studio.

To compile from the command line use the following from the Snap folder:-

	dotnet publish -c Release -r win10-x64

This will generate an executable file in the directory

	\Snap\Snap\bin\Release\netcoreapp2.1\win10-x64

From that directory run using Snap.exe

Alternatively the app can be run using the following from the \Snap directory:-

	dotnet run -p Snap


To view the unit tests execute the following from \Snap directory:-

	dotnet test Snap_UnitTests --verbosity:n
	
![image](https://user-images.githubusercontent.com/28151071/77848872-b9e97b00-71bf-11ea-8c22-8b16b7bc70a6.png)
	
