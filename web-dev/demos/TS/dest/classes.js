"use strict";
/*
Intro to classes and objects and Object-Oriented Programming

An Object is a virtualization of a real world thing.
    Before we talked about an object having properties (person has a name, age and height; house has a sqr footage
        or a number of bedrooms/bathrooms, etc). Objects in the real world can also DO things.
        In programming we can create these objects and each object will have methods associated with it
            - NOTE: A method is function that belongs to an object

A Class is a blueprint for an object
        A Class defines the specific properties an object has and the specific methods associated with that object

Object-Oriented Programming is programming by a variety of classes and objects where these objects do certain
things and emulate the real-world.

In TS, using classes is more common than with JS but both are multi-paradigmed languages (they can be
    used in a variety of ways: OOP, functional, imperative)
*/
class Animal {
    /*
    The first step to properly encapsulate a class is to mark its fields as private (here we're only doing one)
    What is the private keyword?
        Private is an access modifier and can determine WHERE you can access this variable. In this case, only
        inside of this class
    
    If the field is private, how can I update or read the value outside of the class?
        We create special methods called getters and setters (together they're called mutators) that allow
        us to read and change the values ONLY in the ways we specify
    */
    get getSpecies() {
        // This method is a getter and allows us to GET the value for the variable
        return this.species;
    }
    set setSpecies(species) {
        // This is a setter for the species instance variable
        // We can define HOW users are meant to update this variable inside this method
        this.species = species;
    }
    // The compiler is complaining because name and species are possibly uninitialized in the constructor
    // What is a constructor?
    // A constructor is a special method/function used to "build" or construct the object
    constructor(name, species) {
        this.name = name;
        this.species = species;
    }
    // Methods -> functions associated with each object made from this class
    move(feet) {
        console.log(`${this.name} moved a total of ${feet} feet`);
        // When we use the `this` keyword it refers to the specific object
    }
}
// We can create an instance of our class (this is an object) as follows
let perry = new Animal("perry", "platypus");
console.log(perry.name);
console.log(perry.getSpecies);
perry.move(5);
/*
In OOP there are 4 major pillars that are associated with the programming paradigm
Inheritance -> Parent classes and child classes (child takes on the properties/methods of the parent class)
Polymorphism -> Means many forms. Achieved through use of methods with the same name doing
                different things (overloading and overriding)
Encapsulation -> This is like a shield for your data to prevent unwanted manipulation
Abstraction -> Purposefully hiding implementation details to make a simpler user interface
*/
// Inheritance is the ability for one class to inherit from another
class Dog extends Animal {
    bark() {
        console.log("ARF ARF ARF");
        // This method will only be available to the child class and not the parent
    }
    // Polymorphism works hand in hand with inheritance and it's basically is done by a child class
    // providing a new implementation to a parent class method (overriding)
    move(feet) {
        console.log(`The dog ${this.name} moved a total of ${feet} feet. What a good boy!`);
    }
}
let cash = new Dog('Cash', 'Pit Bull'); // Note this constructor comes from the parent class Animal
cash.bark();
cash.move(10);
// perry.bark() doesn't work because perry is an animal not a dog specifically
// Abstraction
// Making the complex simple by hiding implementation details
// We'll accomplish this in TS by using an abstract class with abstract methods
class Car {
}
class Jeep extends Car {
    // Since drive is declared abstact in the Car class every implementing class need to have a method body for 
    // that method
    drive() {
        console.log("The jeep drove around the block");
    }
}
class Tesla extends Car {
    drive() {
        console.log("The tesla drove around the block on electricity");
    }
}
let greenCar = new Tesla(); // Liskov Substitution Principle (abstract class = implementing class)
// NOTE: This is why in Java you'd typically do List<> = new ArrayList<>/LinkedList<>
greenCar.drive();
/*
Why are we spending so much time on classes?
Our Backend will likely end up using OOP so we need the foundation
Angular uses classes for its components, so understanding how classes work will help you further your knowledge
in angular and make it easier to do what you're expecting to do
*/ 
