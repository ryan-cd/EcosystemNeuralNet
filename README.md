# EcosystemNeuralNet
![](http://i.imgur.com/FNqECXF.png)

Description
---
This project is an ecosystem simulation that uses a neural network combined with a genetic algorithm to control the cells. It is an implementation of the challenge question in the [AI Junkie neural network tutorial](http://www.ai-junkie.com/ann/evolved/nnt1.html). 

__Neural Network__

Each cell contains a neural network that functions as its brain by drives its decision making process. The neural network has four inputs:
* The x direction of the cell
* The y direction of the cell
* The x direction of the nearest food source
* The y direction of the nearest food source

The neural network processes those stimuli, and returns two outputs:
* The amount of power to move forward on the cell's left side
* The amount of power to move forward on the cell's right side

(ie the output could return [0.3, 0.4] which would move the cell forward while curving to the left)

Initially the neural networks are given random weights, and the cells have a hard time finding food. Over time, the "brains" are bred to be smarter by seeking out food, as explained below.

__Genetic Algorithm__

The neural networks are trained by a genetic algorithm. Each cell encodes it's chromosome as being a list of all the weights in its neural network. The fitness of a cell is assigned the value of the number of food it collected over it's lifespan. When it is time to make a new generation of cells, the more fit cells are more likely to reproduce, and pass on their weights to the next generation of cells. This way, traits that are unfavourable are bred out, and favourable traits (being able to find food) are more likely to stay.

About the repository
---
The repository is a Unity 5 project. 
