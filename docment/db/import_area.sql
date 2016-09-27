--import csv file into table
bulk insert [dbo].[Area]
from 'D:\document\sql_data\areas.csv'
with(firstrow=2,fieldterminator=',',rowterminator='\n')