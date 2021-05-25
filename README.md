<h1>Dijkstra's algorithm implementation</h1>
<h2>About this project</h2>
It was my task to implement this algorithm for Graphs Theory course at AGH University of Science and Technology.
<h2>How to run</h2>
To run this program you can <a href="https://github.com/echofoxtrotpl/DijkstraAlgorithm/releases" target="_blank">go to releases</a> and download app for your OS: </br></br>
<ul>
<li>macOS portable application (Minimum OS version is macOS 10.12 Sierra)</li>
<li>framework-dependent cross-platform binary (DijkstraAlgorithm.dll)</li>
</ul>
<h2>macOS portable application</h2>
Just download zip and extract it. Then open terminal and type:
  
  ```bash
  cd DijkstraAlgorithm/osx-x64
  ./DijkstraAlgorithm
  ```
<h2>framework-dependent cross-platform binary</h2>
It works on Windows/macOS/Linux.

To run this you will need [.NET Runtime 5.0.6](https://dotnet.microsoft.com/download/dotnet/5.0).

Then download [DijkstraAlgorithm.dll](https://github.com/echofoxtrotpl/DijkstraAlgorithm/releases).

  ```bash
  cd folder_containing_dll
  dotnet DijkstraAlgorithm.dll
  ```
  
  <h2>Usage</h2>
  
 
  1. Prepare .txt file in specified format (lowercase letters for "fromVertex" and "toVertex" and non negative number for "weight"):
 
   
    [fromVertex1, toVertex1, weight1]
    [fromVertex2, toVertex2, weight2]
    [fromVertex3, toVertex3, weight3]
    etc...
    
   for example:
    
    [a, b, 8]
    [b, c, 3]
    [c, d, 2]
    
   or use data.txt from repo files
  
  2. Run program according to instructions given above
  3. Enter path for file which contains data about edges of graph (relative from the folder where executable is located)
     </br>for example: ```../data.txt```
  5. Enter starting vertex (for example: ```a```)
  6. Enter target vertex (for example: ```e```)
  
  <h2>Output</h2>
  
  ```
  -------------------------------
   V a b c d e 
  dV 0 2 5 4 7 
  pV - a b a c 
  Optimal path form "a" to "e" is: a->b->c->e with total cost of 7.
  -------------------------------
  ```
  
