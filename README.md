MVC-Monitor
===========

A tool for reporting unhandled exceptions in real time for ASP.NET MVC applications, including search/filter functionality and a live dashboard.

<h4>How does it work?</h4>

MVC Monitor can receive errors through the popular error catching tools ELMAH and ElmahR. ELMAH catches any unhandled exceptions just before they get thrown from an MVC applicaiton and reports it. The ElmahR extension then posts a JSON representation of the error to a URL of you choice. MVC monitor can receive the posted error and store it. All the errors MVC monitor receives can be seen arriving in real time on the dashboard or searched through via the index.

<h4>Do I need to modify my applications?</h4>

As you've probably guessed, you will need to install ELMAH and ElmahR into you MVC applications.

<h4>Sorted, so how do I start the monitor?</h4>

MVC Monitor is an MVC 4 application which can be hosted on any windows machine using IIS. Simply build the solution, check the unit tests pass and host the application on your server or in the cloud.

<h4>What can I configure?</h4>

*Applications*

MVC-Monitor needs to know which of your applications it will monitor. The app setting in web.config 'Applications' is where you tell it. It is a CSV list of 'sourceId's which you configured in the elmah/error post config value for each of your applications. *N.B. Any errors coming from a sourceId not in this list will be ignored*

*Error repository*

This is where you select which sort of repository is used to store errors. MVC monitor has it's own store for quick access to any errors it receives. Out of the box, MVC monitor is configured to use an in memory repository to store errors. The down side with this method is that the errors are lost if the app pool is restarted. The application can be configured to use an NHibernate repository to persist the errors permanently in a database. 

*Configuring the NHibernate/SQL repository*

To install the database and configure the NHibernate repository:
* Create two new databases MvcMonitor and MvcMonitorTest, for live and tests.
* Run the baseline database script found in MVC-Monitor\MvcMonitor.WebApp\DatabaseMigrations
* In web.config, modify the connection string called MvcMonitor to point to the live database (MvcMonitor) you just created
* In web config change the setting under configuration / appSettings / ErrorRepository value to 'NHibernateRepository'
* In the test project open hibernate.cfg.xml and change the connection.connection_string property to point to the test database (MvcMonitorTest)
* Unignore all the tests under MvcMonitor.Tests/Repositories/NhibernateRepositoryTests
* All the unit tests should now pass and the applicaiton will save all it's data to the database


<h4>So about installing ELMAH into my application...</h4>

To get you application posting its errors to the monitor:

* Create a new or open an existing MVC application
* In the Nuget package manager install Elmah.MVC and ElmahR.Elmah
* *The following config will be added to the web.config file: a section group named elmah, appSettings all prefixed with elmah.mvc, Elmah http modules under system.web, Elmah http modules under system.webserver, and an elmah section including errorLog and errorPost elements.*
* You need to change the errorPost elements targetUrl to point to the monitors elmah error handler (if running locally it is http://localhost:55555/ElmahErrorHandler.axd by default)
* You also need to give it a sourceId e.g. 'MyApp1'. This needs to be added to the csv list of applications on the MVC Monitor web.config.

And that's it! Rebuild you application and make it throw an unhandled exception. This should get posted to the MVC monitor.

It's worth noting that this is only a basic install of ELMAH, including receiving notifications via Prowl and setting up filters to stop certain errors getting posted. See the wiki for details https://code.google.com/p/elmah/w/list 

<h4>Roadmap</h4>
* Update MVC and use web API controllers + all angular front end
* User Login/Auth
* Application keys to prevent unauthorized applications posting to your monitor
* Responsive layout + Reskin using SASS to create theme sheet
* Install scripts
* Component to replace EmlahR error post module
* Owin middleware component for posting errors
