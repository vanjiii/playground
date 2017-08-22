'''
В файл, който се казва n_dice.py, напишете програма, която:

Чете от потребител едно цяло число N
Хвърля зарче с N страни и получава число между 1 и N
Програмата трябва да отпечата на екрана резултата от хвърлянето.
'''

from random import randint

number = input("Tell me a number? ")
number = int(number)

print("The number is {}".format(randint(1, number)))
