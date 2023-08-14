# Note

Note is RESTful api built on asp.net core web api based on design pattern Clean Architecture with using ORM such as EntityFrameWork.

## How to run it?
1. First things first you need to have preinstalled Docker. If you don't have it, than [download it](https://docs.docker.com/engine/install/) it from here.
2. Download **docker-compose.yml** file
3. Open console and go to the location with downloaded file from previous step
4. Paste in console next thing


        docker-compose up

Docker will pull docker image from Docker Hub and it will run it on port 5000.

So, after executing docker image - you will able to test it by next adress, which you should to paste into your browser: 
 
        localhost:5000/swagger
