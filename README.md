# ToDoListWeekSix
ASP.NET project for user identity authentication and authorization implementation.

## Summary

This application is modeled as an application that stores data as a list of to-do tasks.  The purpose is to create user identity through authentication and authorization so that a given user only has access to their specific tasks that are stored in my database.  The database, as will be described below, will contain all of the tasks in our system inside one table that is connected to a user database that correlates specific users with their respected tasks.

## API

There are two databases within this project.  One database is to store all of the to-do list data for all tasks that have been stored through the API.  The other database is to store all of the user information safely and securely so that a user only has access to their specific tasks.  Also, all other users will not have access to any tasks that aren't owned by them.  There will also be implemntation of roles, meaning that their is admin accessibility and user accessibility.
