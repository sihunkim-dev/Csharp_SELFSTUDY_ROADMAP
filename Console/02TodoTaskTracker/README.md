## To-do Task Tracker

### Objectives
- OOP Concepts
- File handling(CSV, JSON)
- JSON Parsing
- LINQ



### Process
- User choose option
  1. View the calendar
     - View the calendar, Ask the month to display:  Display calendar
  2.  View the scedule
      - View the scedule: diplay the weekly scedule
  
  3. Add Task
       - Add Task
: ASK - which date would you want to add ex) 25.4.2026
: Add task
: Set the priority (defalut - 0, highest-1, lowest-10)
every task is indexed by the 
  4. Delete Task
       - 4. Delete
        : Diplay the weekly schedule
        : User can move the next weekly schedule through the 'n' keydown
  5. Update
       -3. Update
: display the weekly schedule
ASK - type date 
ASK - choose task to update by index
 
  6. Quit

## Implementation
1. **Class** : `Task` 
2. **Interface:** : `IStorage` 


TaskItem : `Index(int)`,`date(dateTime)`,`priority(int)`, `Name(string)`  
