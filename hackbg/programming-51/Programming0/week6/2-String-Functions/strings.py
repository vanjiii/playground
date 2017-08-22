
def reverse(input_string):
    result = ""
    index = len(input_string) - 1
    
    while index >= 0:
        result += input_string[index]
        index -= 1

    return result

def join(delimiter, items):
    result = ""
    counter = 0

    for item in items:
        result += item
        counter += 1        

        if counter != (len(items)):
            result += delimiter
       
    return result

def startswith(search, string):
    output_string = head(len(search), string)
     
    if search == output_string:
        return True
    else:
        return False


def head(number, string):
    result = ""
 
    for index in range(0, number):
        result += string[index]
    
    return result


def tail(number, string):
    result = ""
 
    for index in range(number, len(string)):
        result += string[index]
    
    return result


def endswith(search, string):
    end_string = tail(len(string) - len(search), string) 

    if search == end_string:
        return True
    else:
        return False


def trim(string):
    if string == "":
        print("Next time enter a real string..")
        return string

    if string[0] != " " and string[len(string) - 1] != " ":
        return string

    result = ""
    
    for index in range(0, len(string)):
        if string[index] != " ":
            result += string[index]

    return result
