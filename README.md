#Welcome to GroceryCo#

This is my implementation of GroceryCo.

##How the data works

Data storage is just csv text files in a folder in the repositories layer.  You can add new items you want to the catalog and the basket.  If you have invalid files, the csv library is not going 
to have a good time and you will get exceptions.

Catalog.txt
Name,Price,SalePrice

If there is a sale price in the row, the system will use that price.  So in if you want to remove a sale, set that column to 0.00.

Basket.txt
Name

Just fill in the basket with a name of the item you want to buy.  If you add something that is not in the catalog there will be an item not found exception.

##Building and Running

To run the application just build the solution and run the exe out of the console project.  The files will be copied from the repositories folder to the console project's bin folder, so you can modify them 
either in the repository folder pre-build, or in the bin folder after build.

##

Tests are currently green.  I have covered a bunch of sunny day scenarios.  Adding more edge cases would be good at some point.

##3rd party libraries used

Ninject
CsvHelper


