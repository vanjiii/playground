'''
Във файла simple_answers.py, напишете програма, която:

Чете от потребителя някакъв текст.
Спрямо това каква дума се среща в текста, отговаря.
Правилата са следните:

Ако string-a "hello" или думата "Hello" се срещат в текста, отговорете с "Hello there, good stranger!"
Ако string-a "how are you?" се среща в текста, отговорете с "I am fine, thanks. How are you?"
Ако string-a "feelings" се среща в текста, отговорете с "I am a machine. I have no feelings"
Ако string-a "age" се среща в текста, отговорете с "I have no age. Only current timestamp"
Ако в текста се среща повече от 1 от думите, за които гледаме, отговорете с това, с което първо проверявате.
'''

txt = input("Enter some text: ")

if "hello" in txt.lower():
	print("Hello there, good stranger!")
elif "how are you?" in txt:
	print("I am fine, thanks. How are you?")
elif "feelings" in txt:
	print("I am a machine. I have no feelings")
elif "age" in txt:
	print("I have no age. Only current timestamp")
