'''
В файл, който се казва n_dice_more.py, напишете програма, която:

Чете от потребител едно цяло число N
Хвърля зарче с N страни и получава число между 1 и N
Хвърля зарчето още 1 път.
Хвърля зарчето 3ти път.
Програмата трябва да:

Отпечатва всеки път на екрана, когато хвърли за число
Накрая, трябва да отпечата сумата на 3те числа, които е получила след хвърляне на зарче.
'''
from random import randint

number = input("Tell me a number? ")
number = int(number)

random_int1 = randint(1, number)
print(random_int1)
random_int2 = randint(1, number)
print(random_int2)
random_int3 = randint(1, number)
print(random_int3)

print("The sum of the number is: {}".format(random_int1 + random_int2 + random_int3))
