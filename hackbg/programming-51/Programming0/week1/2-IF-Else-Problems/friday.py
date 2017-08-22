'''
Имате следната задача:

Разберете какво прави този код. Пуснете файла и експериментирайте!
Допишете код към файла, така че ако е петък, да изпише It is friday!
Ако не е петък - да напише It is not friday ;( Today is ......, 
	като на мястото на ...... да пише днешния ден.
'''

import time
import datetime

day = "friday"
today = time.strftime("%A")

today = str(today)
#day = str(day)

if today.lower() == day:
	print("It is Friday")
else:
	print("It is not friday ;( Today is {}".format(today))

#print(today)
