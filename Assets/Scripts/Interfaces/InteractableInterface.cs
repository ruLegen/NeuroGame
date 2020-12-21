using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable {
    // source is object who initiated interaction
    void onInteract(GameObject source);
    void onEndInteract(GameObject source);
}
