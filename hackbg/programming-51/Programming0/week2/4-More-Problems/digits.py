'''
Във файл digits.py, напишете програма, която:

Чете едно цяло число n от потребителя.
Превръща числото в списък от неговите цифри (започвайки от първата)
Изкарва на екрана получения списък
След което от списъка с цифри, отново получава числото n
Изкарва полученият резултат на екрана
Идеята на задачата е да напишем двете превръщания:

число -> списък от цифри
списък от цифри -> число
'''

n = int(input("Enter n: "))

list_of_int = []

# number -> list
while n != 0:
	digit = n % 10
	n = n // 10
	list_of_int += [digit]

list_of_int.reverse()
print(list_of_int)

# list -> number
new_num = ""

for num in list_of_int:
	new_num += str(num)

'''
i = 0
for d in list_of_int:
	i = i * 10 + d
'''

new_num = int(new_num)
print(new_num)