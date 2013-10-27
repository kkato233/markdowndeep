markdowndeep
============

Open-source implementation of Markdown for C# and Javascript

https://help.github.com/articles/github-flavored-markdown

にある機能を一部実装する。

## Newlines

入力されたように改行する。
（Issue では 動作するが、Readme.md では動作しない）

```
Roses are red
Violets are blue
```
Roses are red
Violets are blue

<pre>
Roses are red
Violets are blue
</pre>

## Multiple underscores in words

アンダースコアは 強調ではない。

```
perform_complicated_task
do_this_and_do_that_and_another_thing
```

perform_complicated_task
do_this_and_do_that_and_another_thing

<pre>
perform_complicated_task
do_this_and_do_that_and_another_thing
</pre>

## URL autolinking

URL が自動リンクになる

http://github.com

## Strikethrough

取り消し

`~~Mistaken text.~~`

~~Mistaken text.~~

<pre>
<del>Mistaken text.</del>
</pre>

## Task Lists

タスクリスト。
これも Issue では 動作するが、Readme.md では動作しない。


```
- [ ] a task list item
- [ ] list syntax required
- [ ] normal **formatting**, @mentions, #1234 refs
- [ ] incomplete
- [x] completed
```

- [ ] a task list item
- [ ] list syntax required
- [ ] normal **formatting**, @mentions, #1234 refs
- [ ] incomplete
- [x] completed


