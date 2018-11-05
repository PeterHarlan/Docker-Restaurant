# Docker-Restaurant
<kbd>
 <p align="center">
  <img src="https://github.com/pharlan97/Docker-Restaurant/blob/master/Screen%20Image.png">
 </p>
</kbd>


## Overview
This project is a Restaurant app called Docker. This project was created using Unity. I decided to use Unity because I am more familiar with this IDE over other mobile development IDE (such as Xamarin, XCode, and Android Studio). Moreover, based on my research, Unity seems to make cross platform development more streamline and easier. If Xamarin forms is not used when using the Xamarin IDE for cross platform development, UI development for each platform is more segregated, making the cross-platform development lass streamline. Lastly, Unity allows the app to be tested in Play mode so that there is no need to build an APK every time I want to test a newly implemented component in the app. 
For my project, I created a Food class that holds the different meals available in my app; the Food class inherits from Unity’s ScriptableObject class instead of MonoBehavior (the standard way to store data in an application). The Food class holds a title, description, quantity, price, calculated cost, and artwork. Some of these variable values are public because this support’s Unity’s drag and drop feature.  
Because this was such a simple app, I decided to use only one scene. This helped reduce the complexity of the overall project. Since I used one screen, I divided up my screen into two portions. The top potion is a scrollable object that contains multiple menu objects. The second, bottom portion is a fixed panel that holds the calculated cost, bill, tax, total, and tip.  

## Main Screen 
Going with the coastal theme, I decided to base my color scheme in teal. Moreover, I added a background image to give the app a bit more color. Besides the design, the functionalities included in my app allows the user to enter the quantity number of each meal they would like to order. After that, they can use a sliding selector to calculate a certain percentage of the billed amount after the tax is added (a 6% tax is added to the bill amount). The user can split the bill among x number of users by using the increment and decrement button to manipulate the people count. The Total is then divided by the number of people to calculate the cost per person. Lastly, at any point, if the user wants to start over, they can click the Reset button.   

## Known problems, bugs, limitations, unimplemented features. 
After thorough testing, I have not found any bug associated with my project. Later down the road, I would like to link a database to the app that stores the information for the Food class. This will allow the menu item to be generated based on the database instead of hard coded into the app. 

## References
https://unity3d.com/

https://www.vecteezy.com/vector-art/123036-free-flat-crab-vector-illustration

