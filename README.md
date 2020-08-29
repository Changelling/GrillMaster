# GrillMaster

GrillMaster is an implementation of the 2D bin packing problem, which helps to optimize the order in which menu items are grilled on the barbecue.

The 2D Bin packing problem consists of, given a set of 2D pieces, we have to place them in a series of rectangular bins minimizing the material used; in other words, place all the pieces in as few bins as possible. 
The problem is NP-Hard, thus there is no guaranty that an algorithm will provide an optimal solution, although we can compare different solutions in terms of how many bins an algorithm has used for a particular set of pieces. This project tries a few heuristics and approximations in order to solve the problem with a reasonable amount of computational effort, given that a brute force approach to the problem would take virtually an infinite amount of time.
