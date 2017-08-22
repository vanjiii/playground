from datetime import datetime

year_days = 365

first_name = input("Enter first name: ")
second_name = input("Enter surname: ")
family_name = input("Enter your family name: ")

birthday = input("Enter birthday (m/d/y): ")
date_format = "%m/%d/%Y"
birth_day = datetime.strptime(birthday, date_format)

present_day = datetime.strptime("{}/{}/{}".format(datetime.today().month, datetime.today().day, datetime.today().year), date_format)

year = int((present_day - birth_day).days) // year_days



person = {
	"first_name" : first_name,
	"second_name" : second_name,
	"family_name" : family_name,
	"current_age" : year,
	"birth_year" : birth_day.year
}

print(person)
