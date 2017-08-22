
def count_vowels_consonants(word):
	english_vowels = "aeiouyAEIOUY"
	english_consonants = "bcdfghjklmnpqrstvwxzBCDFGHJKLMNPQRSTVWXZ"
	result = {
		"vowels" : 0,
		"consonants" : 0
	}

	for letter in word:
		if letter in english_vowels:
			result["vowels"] += 1
		else:
			result["consonants"] += 1

	return result


print(count_vowels_consonants("aaaAcccD"))