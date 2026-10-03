# gishadev-tools-example

Example Unity 6 project demonstrating two of my own tools, included as git submodules under `Assets/_Project/Scripts/`.

## [gishadev-tools](https://github.com/gishadev/gishadev-tools)

A toolkit to polish your game: audio, pooled effects, events, state machines, scene loading, saving, and general-purpose extensions. See its [README](Assets/_Project/Scripts/gishadev-tools/README.md) for what's inside and how to use it.

## [unity-setup](https://github.com/gishadev/unity-setup)

An editor window (`Tools → gishadev → Unity Setup`) that scaffolds a new project's folders and imports the packages/assets used in every project. See its [README](Assets/_Project/Scripts/unity-setup/README.md) for what each step does.

## Getting started

Clone with submodules so both tools are pulled in:

```bash
git clone --recurse-submodules https://github.com/gishadev/gishadev-tools-example.git
```

Already cloned without them?

```bash
git submodule update --init --recursive
```

## License

MIT — see each submodule's own `LICENSE`.
