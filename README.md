# TEA Project
TEA Project is a project that objective to provide a tool for children with autism to learn, offering real belief lessons.

  - Friendly interface
  - Multi platform
  - Virtual Reality
  - Rewards

It is powered by Unity Engine

## Requeriments
- Unity (*Last version*)
- Visual Studio or other IDE compatible
- Android Studio (*Last version*)
- XCode (*Last version*)
- DB Browser for SQLite or other compatible
- Git

## Download the repository
You can download the repository from your git client like SourceTree, Git Kraken, Git Extensions or you can execute the following command:
```
git clone https://github.com/CarlosSaavedra96/TEA-Project.git
```

## Open the project
To open the project it is necessary to open Unity and select the folder of the downloaded repository folder.

## Create new models
To create new models it is necessary create a `class` with the next content in the models folder:
```
using UnityEngine;

namespace Entities.Models
{
    public class <NameModel>Model : ModelBase
    {
        public <NameModel>Model()
        {
            name = "<NameTable>";
        }
    }
}
```
But it is also necessary to have a program to handle SQLite databases, to create the new table and to be able to use the model.

### Functions
1. GetAll function:
This function obtains all records of the model.
```
//  Returns a list of string array with all records in a model
GetAll()
```
2. GetBy function:
This function obtains all the records of the model but allows to select certain fields.
```
//  Receives a array of strings '[id,name,username]'
GetBy(string[] fields)
//  Receives a string separated with comma 'id,name,username'
GetBy(string fields)
//  Receives a string for condition and a array of strings '[id,name,username]'
GetBy(string condition, string fields)
//  Receives a string for condition and a string for fields separated with comma 'id,name,username'
GetBy(string condition, string fields)
```
3. Insert function:
Allows you to insert a record into a model.
```
//  Receives a array of strings '["12312-1232","Martino","martXinc89"]' for values
Insert(string[] values)
//  Receives a array of strings '["12312-1232","Martino","martXinc89"]' for values and a array of names fields
Insert(string[] fields, string[] values)
```
4. Update function:
Allows you to update multiple records of a model.
```
//  Receives a string which contains the text of the fields to update
Update(string fieldQuery)
//  Receives a string which contains the text of the fields to update and condition text
Update(string condition, string fieldQuery)
```
5. Delete function:
Allows you to delete multiple records of a model.
```
//  Delete all records in a model
Delete()
//  Delete all records that meet the condition
Delete(string condition)
```

### Note
- It is possible to add more functions if necessary, for more information check the class `SQLiteAdapter` in the Adapters folder.

## Export data to CSV file
To export data to CSV file it is necessary import the `StorageCSV` class:
```
using Entities.Utils.Storage;
```
Now to export the data you must call the Save function of the StorageCSV class:
```
StorageCSV.Save(string FilenameWithCSVFormat, List<string[]> data);
```
where the first parameter is the name of the file together with the `.csv` format and the second one receives a list of fixes of `string`.

### Note
- It is possible to export data obtained from the project models, but if you want to export data from related tables it is necessary to review the documentation.
- It is always necessary to add in the first line of the list to export to `.csv` the names of the columns and verify that it is of the same number of columns to avoid problems.
