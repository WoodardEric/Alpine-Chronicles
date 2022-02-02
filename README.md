# Alpine-Chronicles
A 2D adventure game made in Unity

![image](docs/Alpine_Computing.png)

## Gantt Chart
[Gantt Chart](https://vandalsuidaho-my.sharepoint.com/:x:/g/personal/mill7025_vandals_uidaho_edu/EXpynLxGfpdInh3KsIjbctoBXEMf71t_pLgpgAv0CJ7YLg?e=4%3ANP0L1p&at=9&CID=bf6aea30-80ca-0056-3520-f6a0321edc72)


# What is Git?

Git is version management and collaboration software. It will be especially important to you in this class as it facilitates parallel software development from remote locations. On it's own, git is version management software, allowing you to record changes along the development process and revert to them as you desire. This, combined with software repositories such as Microsoft's GitHub, the open-core site GitLab, or Atlassian's BitBucket, allows you to store and track your software and its development history at a centralized, remote location, enabling collaboration among multiple developers and locations.

# How do I set up a repository?

## I. Create a repository

First, we want to get set up with a hosting service for our repository. Some examples of these are GitHub, GitLab, and BitBucket. For this example we will be using GitHub.

1. Navigate to **GitHub's Website**.

	[GitHub](https://github.com/)

2. **Create an account** by accessing the "Sign Up" page or log in to an existing GitHub account.

	[Sign Up](https://github.com/signup?ref_cta=Sign%20up&ref_loc=header%20logged%20out&ref_page=/&source=header-home)

3. Under the left-hand repository management panel, select "New" to **create a new repository**.

	[New repository](https://github.com/new)

4. After naming and optionally entering a description for your new repository, decide whether you wish the repository to be **public** or **private**.

	Public repositories can be accessed by anyone, whereas Private repositories must be explicitly shared by yourself before being accessed by another person. Both require explicit permission to be edited by others.

5. [optional] Check to box to **add a readme file**.

	This will include a `README.md` file in the root directory of your GitHub repository. This will allow you include information and documentation relevant to your repository using [Markdown](https://www.markdownguide.org/), a simple language for basic formatting. This information will be displayed for easy access at the home page of your repository.

	Here is a link to the GitHub page of the free and open source project [Howdy](https://github.com/boltgolt/howdy) if you wish to see an example of how GitHub `README.md` files are typically used.

	If you wish, using a markdown editor may be helpful for formatting, such as the free and open-source [StackEdit](https://stackedit.io/).

6. [optional] Check the box to add a **`.gitignore` file** and chose a template if relevant to your project..

	A `.gitignore` file allows collaborators on your git-managed project to store files alongside their local repositories without affecting the repository itself, enabling changes specific to local machines and reducing repository bulk and remote transfer sizes.

	If your project makes use of common development software or practices, such as Unity, a preconfigured `.gitignore` may be available from the dropdown.

	If you wish to make your own `.gitignore`, or customize an existing one, see Git's `.gitignore` [documentation](https://git-scm.com/docs/gitignore).

	The previously mentioned Howdy GitHub page might be useful as an example for `.gitignore` construction as well.

## II. Configure your repository

All That's really important here for now is adding collaborators to your project.

1. Navigate to the "**Settings**" tab along the top of your GitHub repository interface.

2. Select "**Collaborators**" under the "Access" header along the left-hand menu.

3. Select "**Add People**".

4. Search for the GitHub accounts of the people you want to add as collaborators.

# How do I set up my machine to work with my git repository?

## Option 1: GitHub Desktop
GitHub Desktop is a desktop application provided by GitHub, Inc. for simplifying git management through its streamlined graphical user interface, especially when used in tandem with github.com. 

1. Navigate to **GitHub Desktop's Website**.

	[GitHub Desktop](https://desktop.github.com/)

2. **Download** the release fit for the system you intend to work with.

	While there is only official support for Windows and MacOS releases of GitHub Desktop, unofficial releases seem to be available for most Linux distributions, though you will have to consult with your particular distribution for installation.

3. **Launch** GitHub Desktop.

4. **Sign in** to GitHub.

5. Select **Finish** with default settings.

6. **Select your repository** from the list on the right and clone it.

7. Select "**Clone**" from the dialogue that appears.

	This dialogue window lets you choose how you wish to connect to the remote repository, whether through GitHub's integrated solution or a more traditional URL. It also allows you to choose the directory on your local machine where the repository will be stored.

## Option 2:  Git CLI
Interfacing with Git through command line is the more traditional and ultimately more versatile of the two options, though with a potentially higher learning curve, depending on your workflow.

### Cloning a repository
1. Download and **install Git**.

	[Git Download](https://git-scm.com/downloads)
 
2. Using your favorite command-line interface, **navigate to the directory** you wish to store your local repository.

		cd [path to dir]

3. **Clone** the repository using the following command.

        git clone [URL]

	The URL for your repository can be acquired from the "Code" dropdown button located to the upper right of your repository's navigation window, or by simply copying the URL to your repository from your address bar.

### Configuring Authentication for GitHub
In order to push changes to a GitHub repository, we need to set up our local installation of Git to work with GitHub's authentication requirements.
1. Navigate to your GitHub's **Personal Access Tokens** page.

	This can be found by clicking on your profile photo located at the top right of most GitHub pages, selecting "Settings" from the dropdown, selecting "Developer settings" towards the bottom of the menu on the left of the page, and selecting "Personal access tokens" from the new menu on the left of the page.

	[Personal Access Tokens](https://github.com/settings/tokens) 

2. Select "**Generate new token**".

3. **Configure** your access token.

	Generally, you will only need to set an expiration and check "repo", but [documentation](https://docs.github.com/en/developers/apps/building-oauth-apps/scopes-for-oauth-apps) is available should you wish for more granular GitHub authentication control.

4. Copy and **record** the provided access token.

### Configuring Git Authentication
1. Back in your CLI, use the following command to configure git to **store any authentication credentials** you input.

		git config --global credential.helper store

Now we need to to trigger an authentication request. To do this we will make an arbitrary change to our repository and push it to GitHub.

2. **Change the working directory** of your CLI to that of your local repository we created through git's clone command earlier.

		cd [path to dir]

3. Make a **change**.

	The following command is how you would achieve this on most Unix-like systems like MacOS or Linux, but how you achieve this is arbitrary, as long as some change to the directory is achieved.

		touch [filename]

4. Inform Git of any changes using **add**.

		git add [path to changed file or directory]

	To simply add all changes in the repository's directory, use `.` as the path. Git will automatically determine what has been changed. The simple command is `git add .`

5. Record the changes with Git using **commit**.

		git commit -m [commit message]

6. Upload the changes to GitHub using **push**.

		git push

7. Enter your GitHub credentials using your previously recorded personal access token as your password.

# Git Workflow
Before starting make sure that you are in the root directory of the project in terminal or have the projected loaded on a gui application.

## Setup

First navigate to your teams main repository, Tl1 should send you a link to their github repository. Star this repo, or save it in any way you choose. This is where you will be submitting assignments. 

## Definitions

### Repository
Like a project folder, or C disk drive. It stores all your current working projects. 

### Branches
Each branch is essentially a pointer to a snapshot of changes to the repo and any commit will only affect the selected branch on git. To list all branches, use ‘git branch’. To change the current working branch use ‘git switch <branch name>’ For this project we will only use the ‘main’ branch.

### Pull
Use ‘git pull’ to download any changes from the online repository. This should be the first thing you do anytime you start coding. You will want your code to be up to date with your team since you will be using some of their functions. Also if changes are made to the same line of code then there will be a merge conflict which will have to be resolved before you can push your code to the repo. In this class though we shouldn’t have to worry about that sense no one should be working on the same file.

### Staging
Each change that you want to commit first needs to be staged. Use ‘git add’ to stage any changes or added files to the current branch. You can add single files, directories, every change in the branch, or do it interactively by hunks. Note that adding every change at once is fast and easy it also makes it easy to add unwanted changes without realizing it.
* ‘git add <path>’ stages a single file or directory 

* ‘git add .’ a period means to add every change in the repository 

* ‘git add –p' interactively select chunks of code to stage. Note can’t be used to add new files

### Commit
Use ‘git commit’ to save any staged changes to the current local branch. To stage a change us ‘git add <file name>. 

* ‘git commit –a' commits all changes in the working directory. Not only staged changes. 

* ‘git commit –m ”commit message”' adds a message to the commit. Every commit should have a message and it should be a brief description of what the changes do.  

* ‘git commit –am “commit message”’ Commits all changes with a message. 

### Push
‘git push’ will upload all the commits from your local branch into the online git repository. Do this when your code is at a point where it is ready to be shared with the group. You should generally not push code that does not compile or is broken. Also make sure all your changes are committed before pushing.

### In-depth git guide
For advanced git knowledge, refer to the [git guides published on GitHub](https://github.com/git-guides/).

# Version Control
You may find that, having made too many unfamiliar changes to a branch at once before testing, its contents have ceased to function. Alternatively, you accidentally committed or pushed unwanted changes by accident. When something like one of these cases happens, and you either wish to troubleshoot the problem or just ensure that you have a functional product to present, you will want to revert to an earlier version that you know works.

## Identify Commit to Revert To

To begin, you will want to have the full version history of your branch so that you can identify which version you want to revert to. 

### Website

Browse to your Git branch -> Insights -> Network -> Click on commit

### Desktop

Open your Git repository -> History -> Click on commit

Once you click on a specific commit, you will be able to identify which files have been changed since the previous version of the branch was pushed, as well as specific changes within the files. 

### Terminal

Open your Git repository directory -> 'git reflog'

___

For your later convenience, you should have a meaningful commit message for each commit as well as possibly a quick status update indicating whether the previous version was functional at the time of commit. That way, if you encounter any dysfunctionality in a branch in the future, you will be able to quickly recognize which commits for that branch you can safely revert to. 

## Revert the Change

The website will not work for this step; transition to the GitHub desktop app or the terminal. It is highly recommended to use the terminal for this step, as the process is much less tedious if numerous commits are to be reverted.

### Desktop

There are two options for reverting to a specific commit on the GitHub Desktop app.

1. From the History tab in the current Git repository, right click on every commit to be undone and select 'Revert changes in commit'. This is fine for singular or small amounts of commits to be reverted, but if they are greater in number, the second following option may be more convenient.

2. From the History tab, right click the commit to revert to and 'Create branch from commit'. Replace the files in the current repository with the files generated from the new branch, and commit/push the new branch with Git. This manual labor is unideal, which is why use of the terminal is instead recommended.

### Terminal

Once you have typed

    git reflog

The commit history of the repository should show, with each commit entry beginning with an associated ID.

To revert the changes of one specific commit, type

    git revert <COMMIT_ID>
    
Where <COMMIT_ID> is replaced with the ID found from reflog.

To revert TO a specific commit, undoing all changes that were committed after it, type

    git revert <COMMIT_ID>..HEAD
    
The repository will be reverted to that specific HEAD commit.
