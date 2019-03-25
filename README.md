# CalculApi

## Description
Little .NetApi wich do some calculs (Only additions at the time, more to come)

## Installation
Just run it locally on IIS Express or on a IIS Site.

##Usage
Only `GET` get that do addition for now :

Body :
```JSON
{
"expression" : "1+2+3+4+12+34"
}
```

Expected answer:
Response : 200 OK
Body :
```JSON
{
"result" : 56
}
```

## Tests
You can find some unit tests in the `UnitTestCalculApi` folder 


## SDK Requirements
* Microsoft.AspNetCOre (2.1.1)
* Microsoft.NETCore.App(2.1)
