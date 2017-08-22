#include "banana.h"


Banana* Banana::createBanana(const char *FileName) {
    //create an object using empty constructor
    Banana *sprite = new Banana();
    //if this object was created &&
    //and init the sprite with the file name
    if(sprite && sprite->initWithFile(FileName)) {
//        keep track of the memory of our sprite
//        release it at the right moment
        sprite->autorelease();
        return sprite;

    }
    //if something does wrong -> use this macro
    CC_SAFE_DELETE(sprite);
    return NULL;
}
