# MbitionCodingChallenge
The goal of this challenge is to create an *Event Management System* where users can manage events.
This project was made using C# and dotnet.

You can watch this [Demo](https://www.loom.com/share/b2c70253ce564f7c95eeb70787d358c5) to get an overview of what I have done.

to test this project make sure you have a compiler compatible with C# code and/or have .net SDK installed

then clone this project
```
  git clone https://github.com/MahdiAghaali/MbitionCodingChallenge/
  cd MbitionCodingChallenge
```
use the run command to run the project
```
  dotnet run
```

## Notable features that I have implemented:
- CRUD methods for Event object
  -  Create
  -  Update
  -  Read
  -  Delete
- Implemented smooth workflow where users and fluently perform task from the event list. while viewing the list users can select an event to view all of the details about and choose to edit or delete it.
- Implemented a simple fuzzy search algorithm so users can search for a specific keyword in the name, location or description of existing events (even though their text might not be an exact match) so they can find their desired event faster instead of looking through the list.
- Take into account various edge cases to prevent future crashes and bugs.

## Possible features to be added in future
- This small project could be turned into a simple API so it has a possibilty to be used by any front end technology in the future
- A database could be added to the project so the list of events could be stored properly without losing any data or hardcoding any parameters.
- Locations could be turned into their own seprate class so each of them have a name and ID so users can select from existing locations instead of typing the locations each time
