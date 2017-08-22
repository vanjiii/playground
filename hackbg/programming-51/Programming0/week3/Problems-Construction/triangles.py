from math import sqrt

def is_triangle(a, b, c):
	if a >= b:
		if (a-b) < c and c < (a + b):
			return True
		else:
			return False
	else:
		if (b - a) < c and c < (a + b):
			return True
		else:
			return False

def area(a, b, c):
	p = (a + b + c) / 2
	return sqrt(p * (p - a) * (p - b) * (p - c))

def is_pythagorean(a, b, c):
	if ((a ** 2) + (b ** 2)) == (c ** 2):
		return True
	else: 
		return False

def max_area(triangles):
	#[[1, 2, 3], [2, 3, 4]]
	index = 1
	biggest_triangle = 0
	temp_max_area = 0
	for trg in triangles:
		if temp_max_area < area(trg[0], trg[1], trg[2]):
			temp_max_area = area(trg[0], trg[1], trg[2])
			biggest_triangle = index
		index += 1

	return biggest_triangle

print(is_triangle(3, 4, 5))		
print(is_triangle(4, 4, 4))
print(is_triangle(12, 20, 1))

print(area(4, 5, 6))

print(is_pythagorean(3, 4, 5))
print(is_pythagorean(3, 4, 6))

print(max_area([ [3, 4, 5], [7, 8, 9] ]))