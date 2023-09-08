A. Timesheet add function, 

1. Input validation should be performed before adding the timesheet. It includes
   - required field (all)
   - valid range (0 < hours < 24)
   - valid pattern e.g. no special character in name (first name, last name, project)

   (Please refer to the sample in index.cshtml, Timesheet model & TimesheetController Index method) 

2. Duplicate check should be added. Same staff, same project and same date shouldn't have more than 1 records

3. Standardize the user friendly name in model in single place. Apply it throughout the system for consistency  

   (Please refer to timesheet model and index.cshtml)



B. Unit Test, 

1. Boundary cases should be added 
    - Empty input
    - Not a valid date
    - Not a valid hours ( 0 < hours < 24)
    
2. Add duplicate input checking 
