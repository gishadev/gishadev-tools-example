# gishadev-tools-example

Example **Unity 6** project demonstrating [`com.gishadev.tools`](https://github.com/gishadev/gishadev-tools) — a toolkit to **polish your game**: audio, effects, pooling, events, state machines and more.

> _"Tools to polish your game. Audio, Effects and a lot of other stuff!"_

| | |
|---|---|
| **Unity version** | `6000.0.36f1` (Unity 6) |
| **Tools package** | `com.gishadev.tools` v1.1.3 |
| **Author** | [Bohdan Tsaplia](https://gishadev.com/) |

## Repository layout

```
Assets/_Project/
├── Audio/            Music & SFX
├── Materials/
├── Prefabs/
├── Scenes/
├── Settings/
└── Scripts/
    ├── gishadev-tools/   ← submodule: the tools package (com.gishadev.tools)
    ├── unity-setup/      ← submodule: editor project-setup automation
    └── Test/
```

The two folders under `Scripts/` are **git submodules**:

| Path | Repository |
|------|------------|
| `Assets/_Project/Scripts/gishadev-tools` | https://github.com/gishadev/gishadev-tools.git |
| `Assets/_Project/Scripts/unity-setup`    | https://github.com/gishadev/unity-setup.git |

## Getting started

Clone **with submodules** so the tools package and setup scripts are pulled in:

```bash
git clone --recurse-submodules https://github.com/gishadev/gishadev-tools-example.git
```

Already cloned without them? Initialize afterwards:

```bash
git submodule update --init --recursive
```

Then open the project with Unity **6000.0.36f1**.

## What's inside the tools package

`com.gishadev.tools` (under `Assets/_Project/Scripts/gishadev-tools/Runtime`):

- **Audio** — audio management & playback
- **Core** — shared building blocks
- **Effects** — VFX helpers
- **Events** — event channels (ScriptableObject-based)
- **Infrastructure** — app/bootstrap plumbing
- **Pooling** — object pooling
- **SceneLoading** — async scene loading
- **StateMachine** — lightweight state machine
- **UI** — UI utilities
- **WebGLTemplates** — custom WebGL build templates

Editor tooling (`Editor/`): `AudioEditor`, `PoolEditor`, `EditorDropAreaCreator`, `PolishEditorStyles`.

## Editor setup helpers

The `unity-setup` submodule adds a **`Tools/Setup`** menu to automate first-time project setup:

- **Create Folders** — scaffold the standard project folder structure
- **Import Essentials** — install core packages (UniTask, VContainer, PrimeTween, …)
- **Import polishing tools** — install `com.gishadev.tools`
- **Import Odin** — import Odin Inspector (from Asset Store cache)
- **Import Editor Helpers** — import vFolders 2 / vFavorites 2

## Key dependencies

- [UniTask](https://github.com/Cysharp/UniTask) — allocation-free async/await
- [VContainer](https://github.com/hadashiA/VContainer) — dependency injection
- [PrimeTween](https://github.com/KyryloKuzyk/PrimeTween) — tweening
- Unity Cinemachine, Timeline, AI Navigation, uGUI

## License

The tools package is distributed under the license in
[`Assets/_Project/Scripts/gishadev-tools/LICENSE`](Assets/_Project/Scripts/gishadev-tools/LICENSE).
