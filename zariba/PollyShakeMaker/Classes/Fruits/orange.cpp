#include "orange.h"

Orange* Orange::createOrange(const char *FileName) {
    Orange *sprite = new Orange();
    if (sprite && sprite->initWithFile(FileName)) {
        sprite->autorelease();
        return sprite;

    }
    CC_SAFE_DELETE(sprite);
    return NULL;
}
















