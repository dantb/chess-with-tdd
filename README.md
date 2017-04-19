# ChessWithTDD
As a learning exercise I've decided to create a chess game and engine from scratch. All of the components use Microsoft technologies; the code is written in C# and the board UI uses WPF. The components are:

ChessWithTDD - The board representation or back-end for the game. I'm writing this using test-driven development with Rhino Mocks and NUnit. This contains all the rules of chess; including move validation and check/mate evaluation. Every line of code in this library should be covered by a unit test. The unit tests themselves reside in the "Tests" folder in the project.

ChessGameController - The main executable and host for the game. This currently has a basic UI to choose a team and start the game. It launches the WPF board GUI and in future will be used to choose whether to play against a human or a bot opponent.

ChessGameUI - The board front-end for the game written in WPF. This uses data binding to bind to the underlying board representation. It supports drag-dropping to move pieces and validation happens in line with user piece interaction.
