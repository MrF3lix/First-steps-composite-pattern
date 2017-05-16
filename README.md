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

[Add UML diagramm]

## Implementation

The first step was to implemente the tree structure according to the diagramm.

## Known issues

1. Only the first and second level are added to the tree. I suspect that when i get the composite object (AddCHildElements in TreeEnumerableExtension.cs) I add the child elements to this composite object and not to the currentNode object. I could implement the AddChild/RemoveChild Method on the BaseMachineComponent class but then an article object can add a child element aswell.
