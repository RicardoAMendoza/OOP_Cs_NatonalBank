# The National Bank

## Object Oriented Programming

## Project name : prjWin_NationalBank_Rm

Sumer - 2017

## Description

In this project we will introduce concepts of Object Oriented Programming and the relationship between classes.


### This project focuses in the Object Oriented Programming.


### [Problem](https://github.com/RicardoAMendoza/OOP_Cs_NatonalBank/blob/master/documents/420-DWA-TT_Labo_2.pdf)

A bank has several agencies spread over the Quebec territory. A bank is characterized by the name of its director, 
its global capital, its own name and the address of its head office.


### Summary of classes :

We have these classes and their propierties.

![Summary of classes](/img/organization.jpg "Summary of classes")



After the analysis we get the following relationship between classes. We must complete the diagram using the required symbols to specify 
 *abstraction, encapsulation, inheritance, and polymorphism.*

 
### Inheritance :


![Class Diagram](/img/classes.jpg "Class Diagram")


We did the analysis and we get the next classes diagrams.



### abstract class clsAccount :

![Class Diagram Account](/img/account.jpg "abstract class clsAccount")



### abstract class clsHuman :

![Class Diagram Human](/img/human.jpg "abstract class clsHuman")



### Final class diagram developed :

We implemented with C# and Visual Studio the abstract classes account (clsAccount) and human (clsHuman) and all their offspring.


![Class Diagram Developed](/img/Class_Diagram_StrategyPattern.jpg "Class Diagram Developed")


We write in C# a program to test our class diagram and to handle the whole bank, employees, clients and accounts info. 



### Concepts.

#### Encapsulation is -

 * Hiding Complexity,
 * Binding Data and Function together,
 * Making Complicated Method's Private,
 * Making Instance Variable's Private,
 * Hiding Unnecessary Data and Functions from End User.
 
Encapsulation implements Abstraction.


#### Abstraction is -
 
 * Showing Whats Necessary,
 * Data needs to abstract from End User,
 
[What is the difference between Abstraction and Encapsulation ?](https://www.youtube.com/watch?v=1Q4I63-hKcY)
 
 
#### Inheritance is -

When we can reuse (inherits), the behavior of a super class (parent class) in a child class (class that inherits the members of the base class).

[Inheritance in C# and .NET](https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance)

Not all membersfrom the parent class are inherited in the the child class.

 * Static constructors, *which initialize the static data of a class*.
 * Instance constructors, *which you call to create a new instance of the class. Each class must define its own constructors*.
 * Finalizers, *which are called by the runtime's garbage collector to destroy instances of a class*.
 
 
All members from the super class are inherited to the lower classes, but if they are visible or not depends on their accessibility.*

 * Private, *members are visible only in derived classes that are nested in their base class.*
 * Protected, *members are visible only in derived classes.*
 * Internal *members are visible only in derived classes that are located in the same assembly as the base class.*
 * Public, *members are visible in derived classes and are part of the derived class.*
 
 
 
A child classes can *override* inherited members by providing an implementation in the parent class. 
The member in the parent class have to be marked with the *virtual* keyword.

        Example: from the parent class : 
		
		public abstract class clsAccount
		{
			public virtual bool fncDeposit(double deposit)
			{
				if (deposit < 20 || 500 < deposit)
				{
					return false;
				}
				else
				{
					vBalance += deposit;
					return true;
				}
			}
		}
		
		
		in the child class : 
		
		public class clsPaidAccount : clsAccount
		{
			public override bool fncDeposit(double deposit)
			{
				vInterestPayment = fncPayInterest(deposit);
				fncPaidAccountPayInterest(vInterestPayment);
				MessageBox.Show("an interest of : " + " " + vInterestPayment.ToString() + " $ " + " has been paid ");
				return base.fncDeposit(deposit);
			}
		}
		
		
		
#### Abstract is -		

In a class declaration indicates that this class is going to be a super class, a base class of others classes.
Members with the key word abstract, or included in an abstract class, must be implemented in the lower classes.
Abstract can be used with classes, methods, properties, indexers, and events.

[Key word abstract](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract)


#### [MVC : Model View Controller](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller)


![MVC](/img/MVCmodel.JPG "MVC")



 * Model:      *It should be responsible for the data of the application domain.*
 * View:       *It presents the display of the model in the user interface.*
 * Controller: *It is really the heart of the MVC, the intermediary that ties the Model and the View together.*
               *The controller takes user input, manipulates the model & causes the view to update*

			   
			   
When we have this pattern in one application (MVC pattern), we can reuse code in other application
and work in parallel whit others developers.			   
			   
			   
In the projec we can watch the MVC in the folder projet as follows.  
 
 
![Model-View-Controller](/img/mvc.jpg "Model-View-Controller")



But the heart of the MVC, the controllers are clsDataSource and clsDataSave. The clsDataSource takes the data
from the TXT files, delivers the data as the inputs to the application and the result goes to clsDataSave
and this class save the outputs in XML files.


![Controller](/img/controller.jpg "Controller is the heart of the MVC")



#### Events and delegates

An event is a message sent by an object to signal the occurrence of an action.

 * Events. *Tool that helps communication betwen classes and helps to extend applications.*

A delegate is a class that can hold a reference to a method. 
Unlike other classes, a delegate class has a signature, and it can hold references only to methods that match its signature.
  
 * Delegates. *Agreement / Contract between Publisher and Subscriber, Determines the signature of the event handler method in Subscriber.*
 
  
[Video : C# Events and Delegates](https://www.youtube.com/watch?v=jQgwEsJISy0)  

        
		
		DECLARE AN EVENT
        1. define delegate
           public delegate void AdminDelegate(object source, clsAdminEventAgrs e);
        2. define un event based on the delegate
           public event AdminDelegate ApplicationClosed;

        public event EventHandler<clsAdminEventAgrs> ApplicationClosed;
        public event EventHandler<clsAdminEventAgrs> ApplicationWarned;
		
		3. Raise the event

        public void OnApplicationClosed()
        {
            if (ApplicationClosed != null)
            {
                ApplicationClosed(this, new clsAdminEventAgrs("An event started : you just have 5 minuts in admin control !!"));
            }
        }
		
        public void OnApplicationWarned()
        {
            if (ApplicationWarned != null)
            {
                ApplicationWarned(this, new clsAdminEventAgrs("The application will be closed in 2 minuts !!"));
            }
        }

		

#### Strategy design pattern

Identify families of algorithms as a group technology, gather them and make them interchangeable.

[C# The Strategy Pattern](https://www.youtube.com/watch?v=94t2ayF1l3o&t=316s)

![Strategy design pattern](/img/sdp.jpg "Strategy design pattern")
		

		
### Prerequisites

 * Microsoft Visual Studio Community 2015 Version 14.0.25425.01 Update 3
 * Programming language : C#.
 * Object Oriented Programming.
 
 
## Installation

### Download and install. 

 * [Install Visual Studio](https://visualstudio.microsoft.com/)
 * [Dowland the MVC_ComboBox_selector project](https://github.com/RicardoAMendoza/The_NationalBank_Rm)
 
 
## Author

* **Ricardo Mendoza -  Programmer Analyst**
 
 
 ## Running the tests
 
 
 ## Built With

* [Visual Studio](https://visualstudio.microsoft.com/)


## Versions and source manager. 

This project uses GitHub.com as source manager in the following repository:

https://github.com/RicardoAMendoza/The_NationalBank_Rm


## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

- Copyright Ricardo Mendoza
- the MIT License (MIT)


## Acknowledgments

* [Andy Del Risco](https://www.linkedin.com/in/andydelriscomanzanares/) - MENTOR, *Technicien Informatique Cl. Principale* [École des métiers de l’aérospatiale de Montréal](http://ecole-metiers-aerospatiale.csdm.ca/)
* [Fernand Tonye](https://www.linkedin.com/in/fernand-tonye-6a46532b/) - MENTOR, *Chief d'Equipe Informatique pour les enseignants* [Institut Teccart](http://www.teccart.qc.ca/)
* [Charles Vilaisak](https://www.linkedin.com/in/cvilaisak/) - MENTOR, *Registraire à l'École nationale de cirque* [École nationale de cirque](https://www.linkedin.com/school/-cole-nationale-de-cirque/)
* [Institut Teccart](http://www.teccart.qc.ca/)

