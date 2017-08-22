
#takes list and returns the first element of it
def head(some_list):
    if len(some_list) != 0:
        return some_list[0]

def last(some_list):
    last_index = len(some_list) - 1
    return some_list[last_index]

def tail(some_list):
    result = []
    index = 1
    while index < len(some_list):
        result += [some_list[index]]
        index += 1
    
    return result

def equal_list(first_list, second_list):
    if len(first_list) != len(second_list):
        return False

    index = 0
    while index < len(first_list):
        if first_list[index] != second_list[index]:
            return False
        index += 1
    
    return True

def count_item(element, some_list):
    number_of_occurence = 0
    
    for item in some_list:
        if item == element:
            number_of_occurence += 1
    return number_of_occurence

def take(number, some_list):
    result = []
    
    index = 0
    boundary = 0
    
    if number < len(some_list):
        boundary = number 
    else:
        boundary = len(some_list)

    while index < boundary:
        result += [some_list[index]]
        index += 1

    return result

def drop(number, some_list):
    result = []
    if number >= len(some_list):
        return result

    while number < len(some_list):
        result += [some_list[number]]
        number += 1
        
    return result

def reverse(some_list):
    index = len(some_list) - 1
    result = []
    
    while index >= 0:
        result += [some_list[index]]    
        index -= 1

    return result
