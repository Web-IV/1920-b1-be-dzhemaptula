# 1920-b1-fe-dzhemaptula

# Zound

Frontend: https://github.com/Web-IV/1920-b1-fe-dzhemaptula

Website is running on: https://dzhem.ysebie.be/
Find the RESTful API swagger on: https://dzhem.ysebie.be/swagger/index.html

![](zound.gif)

Use the following account for login:

- Username: web4
- Password: password

The site has HTTPS, so do not worry about your passwords being stolen.
Everything is hashed and stored in the database without a way to unhash them.

(But still; do not use any real passwords. This is not a real site you will be using at this moment.)

You should have a friend request from dzhemaptula right after logging in.
You can use this to test some functionality with posts etc.

All other users can be used with their usernames and password "password"

---

# About me

First name: Dzhem

Last name: Aptula

Class: 2C1

School year: 2019-2020

Favorite languages: C# and (lots of) Python :shipit:

Linkedin: https://www.linkedin.com/in/dzhemaptula/

---

# What is it?

Zound is a social media in it's early stages. It is a huge project to work on, currently having some key functions like searching/adding friends, and showing their posts.

The goal is to continue this project and over time create a social media website where people go to when they want to talk about music and relax by listening to songs synced with other people.

## Todo's

- [x] Create backend models
- [x] Connect a database (localhost)
- [x] Good mapping of database classes
- [x] JWT Authentication
- [x] Create some tests (obviously not TDD.)
- [x] Fix swagger
- [x] Create a good backend
- [x] MVC
- [x] Learn how to use postman to test the endpoints
- [x] Get bored and hack yourway into https://www.hackthebox.eu/
- [x] Test everything and rewrite code that you think is slow
- [x] Create an angular project
- [x] SOME design...
- [x] Friend requesting, accepting, etc
- [x] Posts by friends (timeline)
- [ ] Fix passing data, make it simpler and use less DTOs
- [ ] Implement Signal R with web sockets for synced listening
- [ ] Use web sockets to notify users when they get a friend request
- [ ] Chatting with friends and music rooms
- [ ] Implement Neo4j for the database
- [ ] DECENT design...
- [ ] Use Azure services for hosting, and database
- [ ] more to come...
- [ ] GREAT design ...

# Running the application

## Backend

Clone the backend and fire it up. Be sure to uncomment the datainit in startup.cs

## Frontend

Clone the frontend. Before starting it up, you need the npm packages.
Run npm install before using npm start.
