#TC.BrowserStack.Screenshots

Automate product of screenshots from BrowserStack. Vary url, orientation, browsers etc. Option to download images locally.

WARNING: Not a free service. You require the Team Plus for Screenshots & Responsive to access the API.

Details of json format required here.

http://www.browserstack.com/screenshots/api#generate-screenshots

##Instructions

###Command line

```Screenshots browsers```

Will download the `browsers.json` file to your working directory.

```Screenshots jobs JobsDefinition.json```

Will run a set of jobs across multiple pages with the same default settings. Datestamp logfile created in working directory.

```Screenshots images 2014-10-31-22-14.json```

Will download the images (and wait if not processed yet) to a folder of the same name as the log file.

###Retry Attempts

BrowserStack will allow 4 parallel sessions to take place with the Team Plus account. This application will wait when recieving this warning and retry a number of times. Both can be configured in the jobs file. Expect to see this output on the console.

```
The remote server returned an error: (422) Unprocessable Entity.
Parallel limit reached. Retry 2. Wait 5 minutes.
```
