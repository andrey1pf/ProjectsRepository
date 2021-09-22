#include <iostream>
#include <fstream>
#include <string>
#include <set>

using namespace std;

class TreeNode {
public:
    explicit TreeNode(int Key):
            key(Key), Left(nullptr), Right(nullptr) {};
    int key;
    TreeNode* Left;
    TreeNode* Right;
};

class Tree {
public:
    Tree(): Root(nullptr)
    {
    }

    ~Tree() {
        DestroyNode(Root);
    }

    void Paste(int x) {
        TreeNode** now = &Root;
        while (*now) {
            TreeNode& node = **now;
            if (x < node.key) {
                now = &node.Left;
            } else if (x > node.key) {
                now = &node.Right;
            } else {
                return;
            }
        }
        *now = new TreeNode(x);
    }

    void ShowResult (TreeNode* vert, ofstream& out){
        out << vert->key << endl;
        if (vert->Left != nullptr){
            ShowResult(vert->Left, out);
        }
        if (vert->Right != nullptr){
            ShowResult(vert->Right, out);
        }
    }

    TreeNode* Root;

private:
    static void DestroyNode(TreeNode* node) {
        if (node) {
            DestroyNode(node->Left);
            DestroyNode(node->Right);
            delete node;
        }
    }

};

int main() {
    ifstream input ("input.txt");
    ofstream output ("output.txt");

    string line;
    set<int> vertex;
    Tree tree;

    if (!input.is_open()) {
        cout << "Error opening file!";
        return -1;
    }

    while (!input.eof()) {
        input >> line;
        int res = stoi(line);
        vertex.insert(res);
        tree.Paste(res);
    }

    tree.ShowResult(tree.Root, output);
    input.close();
    output.close();

    return 0;
}