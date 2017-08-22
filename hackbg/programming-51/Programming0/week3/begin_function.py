#power of two

def square(x):
	return x ** 2

#factorial

def fact(f):
	if f == 0 or f == 1:
		return 1

	return f * fact(f - 1)	#recursive call

#elements in list

def count_elements(items):
	for item in items:
		count += 1
	return count

#element in a list ?

def member(x, xs):
	for item in xs:
		if x == item:
			return True
		else:
			return False

#Students with grade 

def grades_that_pass(students, grades, limit):
	#students - list of the names of some students
	#grades - list of grades (float)
	#limit - float number, the limit to filter the students
	#students and grades has same lenght
	result = []
	index = 0
	end = len(grades)

	while index < end:
		if grades[index] > limit:
			result += [students[index]]
			#print(students[index])
		index += 1

	return result

#main function
print(grades_that_pass(["Rado", "Ivo", "Maria", "Nina"], [3, 4.5, 5.5, 6], 4.0))