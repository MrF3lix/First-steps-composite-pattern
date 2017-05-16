# First-steps-composite-pattern

My first steps using the composite pattern. I came across a very interessting problem at work and I wanted to use the composite pattern to solve this problem. 

## Problem

My goal was to display a tree view of all the parts which are used in a machine. A machine is build out of articles and modules.
A module contains of multiple parts and an article doesn't have any child parts.

If the article is in our system a link to the detail page should be shown. For a module the specific number should be displayed without a link.

In our database the parts are stored in a flat table without any recursion. For each part we define a ParentId, if the part doesn't have a ParentId it means, it is the root element. Before I can display the tree view i need to convert the flat list to a tree.

## The idea

The idea was to use the composite pattern to portray the tree structure of the parts in the machine. The user should not know about the differnece between an article and a module. With the composite pattern we can define leafe objects such as article which doesn't have any child parts and we can define a composite object which has child parts.

The tree structure should look something like this:

![uml_class_billofmaterial](https://cloud.githubusercontent.com/assets/7260168/26109446/e5b3ceca-3a4f-11e7-8c05-7f183028fd8a.jpg)

The BaseMachineComponent class is in this case the *Component*, the Article class is a *Leaf* class and the Module class is a *Composite* class. These three types of classes are specified in the description of the composite pattern. 

## Implementation

The first step was to implemente the tree structure according to the diagramm. I decided to add the definition of the AddChild() and RemoveChild() method to the BaseMachineComponent class even though the class Article inherrits from the BaseMachineComponent and should not have the functionallity to add or remove a child. 

To prevent that the Article class has child parts, the implementation in the BaseMachineComponent class is empty and the list with the child parts is only defined in the Module class. The disadvantage of this solution is, that when the client can't access the child parts via the BaseMachineComponent class. To make this somehow possible i followed the implementation guide of the pattern and created a method GetComposite() which in the base implementation returns null. On the module class it will return the current module object and the client can access the child parts.

The biggest issues I faced during the implementation was the creation of the tree structure from a flat list. To solve this I've created an extension class which provides the BuildTree() Method to the list of parts. 

Another issue I had was the output of the tree for which I used a breadt-first traversal. The problem was to display the element on the correct level. For each depth level a "-" should be shown in front of the element. To solve this I've added a variable to store the level and a variable to store the count of elements which are on this level. When taking an element out of the queue the count of elements on this level is reduced. If the count of elements on a level reaches 0 it will add 1 to the depth variable.

## Known issues

1. None at the moment :)
