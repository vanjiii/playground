'''
В файл, който се казва names.py, напишете програма, която:

Чете от потребител първото му име
Чете от потребител второто му име
Чете от потребител третото му име
Изкарва на екрана пълното му име, разделено с 1 шпация между 3те отделни имена.
'''

first_name = input ("What's your first name? ")
second_name = input("what's your second name? ")
last_name = input("What's your last name? ")

whitespace = ' '

print("====That is your name: ====")
print(first_name + whitespace + second_name + whitespace + last_name)
