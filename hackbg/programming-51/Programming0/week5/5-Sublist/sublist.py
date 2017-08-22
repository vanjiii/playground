
def sublist(list1, list2):
	#checks if list1 is sublist of list 2

	if len(list1) == 0:
		return True

	is_list_started = False
	
	index = 0

	while index < len(list2):
		if list1[0] == list2[index]:
			is_list_started = True
			
			#for cases like list1 start with the last element of list 2
			if len(list1) > len(list2) - index:
				return False
				
		else:
			is_list_started = False

		if is_list_started:
			index_l2 = index
			index_l1 = 0
			is_diff = True

			while index_l2 < (len(list1) + index) - 1:
				if list1[index_l1] != list2[index_l2]:
					is_diff = False
					break
				index_l2 += 1
				index_l1 += 1

			if is_diff:
				return True

		index += 1

	return False

#main
print(sublist([1, 2, 3], [0, 0, 1, 2, 3, 5, 6]))
print(sublist(['Python'], ["Python", "Django"]))
print(sublist(["Python", "Django"], ["Django", "Python"]))
print(sublist([1, 2], [1, 0, 1, 2, 2]))
print(sublist([1, 2, 3], [0, 0, 1, 6, 3, 5, 6]))
print(sublist([1, 2, 3], [0, 0, 1, 6, 3, 5, 6, 1, 2]))