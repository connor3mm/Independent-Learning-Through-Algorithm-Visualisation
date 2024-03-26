CS408 Individual Project
This project is a web application that assesses the user’s readiness to learn and facilities their gain for further knowledge in computer science. This knowledge will be acquired through the visualisation of algorithms, employing visual aids, and leveraging interactive tools. By gauging the user's preparedness, the application aims to recommend appropriate learning and resources based on individual proficiency level and allow them to learn at their own pace.

Technologies Used & Installation
This projet is split into two folder, frontend and backend:

Usage
Pulling down the repository from the gitlab url (https://gitlab.cis.strath.ac.uk/ykb20160/cs408-individual-project)
or through the http or SSH link 
ssh://git@gitlab.cis.strath.ac.uk:2222/ykb20160/cs408-individual-project.git
https://gitlab.cis.strath.ac.uk/ykb20160/cs408-individual-project.git
naviagte to the directory you wish to save the project, git clone {address}

Backend: 
Recommendation for backend is to use Rider IDE from jetbrains for running( https://www.jetbrains.com/rider/), if not visual studio is a good alternative 
C# version 12 & .Net 8 must be used due to the identity library being introduced in .NET 8 (- https://dotnet.microsoft.com/en-us/download/dotnet/8.0r)

PostgreSQL (https://www.postgresql.org/download/) choose your OS and at the top, very first line says "Download the installer", click this and install the latest version. Set up with password of your choice, or for simplicity 'password'

Open IDE and open the backend folder, if proper packages are installed then .net should build the project properly.
If not, console logs will tell you which dependencies may be missing
Open the database manager, create new connection, select add data source manually, change data source to postgres and continue, User should be 'postgres' and password 'password'(or your choice), for demonstration purposes in this case.

Within 'nuget', the package manager, instal 'Entitiy Framework Core' version 8
Navigating to the folder 'University Dissertation\BackEnd\API-University-Dissertation' and running the command 'dotnet ef database update --context ApplicationDbContext' should run in the databases seeding. 
If it does not, then going to the 'ApplicationDbContext' file and remove the data from each model builder and running 'dotnet ef migrations add RemoveData --context ApplicationDbContext' will reset the seeding, add the data back to ApplicationDbContext, and then run 'dotnet ef migrations add AddSeedingBack --context ApplicationDbContext', along with the orginal 'dotnet ef database update --context ApplicationDbContext'. 
Backend should now be running

(Optional) For backend testing coverage, dotnet cover is recommend if using Rider IDE


FrontEnd:
For running the front end visual studio code is recommended (https://code.visualstudio.com/download)
Node.js https://nodejs.org/en/download

Make sure on the front end you are in the right directory "<RootDirectory>\CS408 - Individual project\University Dissertation\FrontEnd\Univeristy-Dissertation>"
'npm run dev' to run front end application, which you can click on the URL link or type manually into a browser, should be http://localhost:5173/

Once node.js is installed, running 'npm install -g npm' will install NPM 
Typescript - 'npm install typescript --save-dev'

Running 'npm install -g create-vite' should install the vite react runner. 
There may be a few updates to make, follow the console log to install dependencies need
One will be material ui "npm install @mui/material @emotion/react @emotion/styled"
Axios 'npm i axios'
Jest (optional) 'npm i axios', 'npm test' to run the tests'

Frontend should now be running




