 # Symbolic Regression in C#

This code takes in a series of x,y datapoints and then applies a genetic algorithm to them to generate an equation that will match the x,y values with minimal error. 

This machine learning approach is cover in the following tutorial: https://medium.com/@taran_90075/symbolic-regression-from-scratch-in-c-part-1-f374771862f6

# Extension

There are few ways this could be extended that I would recommend. The genetic algorithm could implement an age algorithm so that it can make more radical changes in an attempt to break out of a local minimum. The algorithm here can get caught in a local minimum fairly easily as its mutations have a limited scope. More significant mutations or similar mechanisms like crossover will be  required.

More obvious utility extensions would be things like loading in data points from external documents and saving equations during mutation by age to later compare and get better results.
