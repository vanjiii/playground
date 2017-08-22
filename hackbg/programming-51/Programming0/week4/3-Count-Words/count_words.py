
def count_words(words):
	map_of_words = {}

	for word in words:
		if word in map_of_words:
			map_of_words[word] += 1
		else:
			map_of_words[word] = 1

	return map_of_words

print(count_words(["words", "are", "meaningful", "words", "words", "are"]))