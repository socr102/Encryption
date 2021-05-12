# AES 256 encryption/decryption using pycrypto library
import base64
from Crypto.Cipher import AES
from Crypto import Random
from Crypto.Protocol.KDF import PBKDF2
import hashlib

from common_kyx import salt

BLOCK_SIZE = 16
pad = lambda s: s.encode() + (BLOCK_SIZE - len(s) % BLOCK_SIZE) * bytes([BLOCK_SIZE - len(s) % BLOCK_SIZE])
unpad = lambda s: s[:-s[-1]]

def get_private_key(password):
	kdf = PBKDF2(password, salt, 48, 1000)
	return kdf[:16], kdf[16:48]

def encrypt(raw, password):
	iv, key = get_private_key(password)
	cipher = AES.new(key, AES.MODE_CBC, iv)
	text = cipher.encrypt(pad(raw))
	return base64.b64encode(text)

def decrypt(enc, password):
	iv, key = get_private_key(password)
	cipher = AES.new(key, AES.MODE_CBC, iv)
	data = base64.b64decode(enc)
	text = cipher.decrypt(data)
	return unpad(text)

if __name__ == '__main__':
    password = input("Enter encryption password: ")
    # First let us encrypt secret message
    encrypted = encrypt("This is a secret message", password).decode()
    #print(encrypted)
    # Let us decrypt using our original password
    decrypted = decrypt(encrypted, password)
    print(bytes.decode(decrypted))
