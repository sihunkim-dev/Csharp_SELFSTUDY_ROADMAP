## To-do Task Tracker

### Objectives
- OOP Concepts
- File handling(CSV, JSON)
- JSON Parsing
- LINQ



----
### Process
- User choose option
  1. View the calendar
     - View the calendar, Ask the month to display:  Display calendar
     - ASK : Enter date to check shedule
         - Display the weekly schedule for the typed date
 
  2.  View the scedule
       - ASK : Enter date to see the task
      - View the scedule: diplay the weekly scedule

  3. Add Task
       - Add Task
: ASK - which date would you want to add ex) 25.4.2026
: Add task
: Set the priority (defalut - 0, highest-1, lowest-10)
every task is indexed by the 
  4. . Delete Task
    -  Delete
        : Diplay the weekly schedule
        : User can move the next weekly schedule through the 'n' keydown
  5. Update
        Update
: display the weekly schedule
ASK - type date 
ASK - choose task to update by index
 


**ENTITY** 
`Index(int)`,`date(dateTime)`,`priority(int)`, `Name(string)`  


## Troubleshootings
- **JSON ISSUE**
  After I created new JSON file, method doesn't recognize the file because the file was 0-byte. So, It was crushed.
  **Solved :** just added { } for parse. + Initialisation method to create new Json file for exception